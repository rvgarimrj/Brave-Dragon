using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class musicHome : MonoBehaviour,IPointerDownHandler {

	public	Sprite[]	buttonImages;
	private	Image 		button;
	private string 		musicState;
	private Main		Main;

	// Use this for initialization
	void Start () {
		Main = FindObjectOfType (typeof(Main)) as Main;
		button = GetComponent<Image> ();
		GlobalVariables.musicState = PlayerPrefs.GetString ("music");
		if (GlobalVariables.musicState == "on") {
			button.sprite = buttonImages [1];

		} else {
			button.sprite = buttonImages [0];
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown(PointerEventData ped)
	{
		if (GlobalVariables.musicState == "on") {
			GlobalVariables.musicState = "off";
			Main.Pause ();
			button.sprite = buttonImages [0];
			PlayerPrefs.SetString ("music", GlobalVariables.musicState);

		} else {
			GlobalVariables.musicState = "on";
			Main.Play();
			button.sprite = buttonImages [1];
			PlayerPrefs.SetString ("music", GlobalVariables.musicState);

		}
	}
}
