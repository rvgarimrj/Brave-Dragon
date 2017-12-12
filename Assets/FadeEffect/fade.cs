using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour {
	[SerializeField] private SpriteRenderer fadeTexture;
	[SerializeField] private float fadeSpeed;
	[SerializeField] private GameObject fadeGO;
	void Awake()
	{
		fadeGO.SetActive (true);
	}
	// Use this for initialization
	void Start () {
//		fadeTexture = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void fadeEffect(string fade)
	{
		StartCoroutine (fade);
	}

	IEnumerator fadeIn()
	{
		Color color = new Color (0, 0, 0, 1);
		fadeTexture.material.color = color;
		for (float f = 1; f > 0; f -= fadeSpeed) {
			color.a = f;
			fadeTexture.material.color = color;
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator fadeOut()
	{
		Color color = new Color (0, 0, 0, 0);
		fadeTexture.material.color = color;
		for (float f = 0; f < 1; f += fadeSpeed) {
			color.a = f;
			fadeTexture.material.color = color;
			yield return new WaitForEndOfFrame ();
		}

	
	}
}
