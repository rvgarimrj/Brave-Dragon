using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class virtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public	GameObject	redPlayer;
	public	string 		command;
	public	Sprite[]	buttonImages;
	private	Image 		button;



	// Use this for initialization
	void Start () {

		button = GetComponent<Image> ();

	}
	
	public void OnPointerDown(PointerEventData ped)
	{
		redPlayer.SendMessage (command, SendMessageOptions.DontRequireReceiver);
//		greenPlayer.SendMessage (command, SendMessageOptions.DontRequireReceiver);
//		yellowPlayer.SendMessage (command, SendMessageOptions.DontRequireReceiver);
//		bluePlayer.SendMessage (command, SendMessageOptions.DontRequireReceiver);
		button.sprite = buttonImages [1];
	}

	public void OnPointerUp(PointerEventData ped)
	{
		button.sprite = buttonImages [0];
	}

}
