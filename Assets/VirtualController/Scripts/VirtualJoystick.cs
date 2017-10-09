using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	private Image	bgImg, joystickImg;
	private	Vector3	inputVector;

	// Use this for initialization
	void Start () {

		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void FixeUpdate () {
		
	}

	public void OnDrag(PointerEventData ped)
	// Usaremos o RectTransform pois precisamos pegar o click/touch somente dentro da área do retangulo da imagem BackGroundImage
	{
		Vector2 pos; // x,y
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			// RectTransformUtility -> Helper do RectTransform
			// ScreenToLocalPointInRectangle -> Pega o click dentro do recttransform convertido
			// Parametros: 
				// bgImg.rectTransform -> A area a ser analisada
				// ped.position	-> o PointerEventData contendo a posicao do clique/touch recebida por OnPointerDown
				// ped.pressEventCamera -> Passa a camera associada ao PointerEventData para ser dinamico
				// out (saida) -> Retorna a posicao clicada dentro do rectTransform

			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
			// Dividmos a posicao X,Y clicada, que é relativa à tela como um todo, pelo tamanho (X = largura, Y = altura) da imagem relativa ao ponto da ancora da tela. 
			// Assim, temos a posicao x,y de dentro do rectTransform para que possamos movimentar o joystickImg simulando um D-Pad

			inputVector = new Vector3(pos.x * 2 - 1, 0, pos.y * 2 -1);

				// Precisamos multiplicar a posicao X e Y por 2 pois estamos dividindo a imagem bgImg em duas (Partindo da
				// âncora central da imagem temos: 	X -> lado negativo à esquerda e positivo à direita
				// 									Y -> Cima positivo e abaixo negativo). 
				// Diminuímos isso de 1 pois em X temos o lado esquerdo da ancora central negativo e o lado
				// direito da âncora central positivo. Em Y temos: Acima positivo e abaixo negativo

				// Este comando já funciona para jogos 3d e 2d pois passamos o Z como sendo o pos.y e o y sendo 0

			if(inputVector.magnitude > 1)
			{
				
				// Se o comprimento do vetor for maior que 1 então normalize, pois não podemos correr o risco de ter o inputVector maior que o tamanho rectTransform
				// de bgImg. Lembrando que os controles X e Y devem estar entre -1 , 0 e 1 pois iremos multiplicar pela velocidade do player para movimentá-lo

				inputVector = inputVector.normalized;
			}

			joystickImg.rectTransform.anchoredPosition = new Vector3 (	inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), 
																		inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
			// Agora vamos movimentar o Joystick. Para isso vamos movimentar as âncoras pois dessa forma a imagem de dentro irá se movimentar relativa ao pai bgImg. 
			// Lembrando que nao podemos ultrapassar o limite da imagem por isso dividimos por 2 novamente pois a bgImg é dividida em 2 (lado esquerdo / direito e cima/baixo)
			// Caso queira que saia menos de dentro de bgImg é só dividir por um valor maior, eu coloquei 3.


		}
	}

	public void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		// Quando soltarmos o mouse ou levantarmos o dedo a bolinha do joystick tem que voltar pro centro
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public float Horizontal()
	{
		return inputVector.x;
	}

	public float Vertical()
	{
		return inputVector.z;
	}
}
