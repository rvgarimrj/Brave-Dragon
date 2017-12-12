using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class music_GameOver : MonoBehaviour,IPointerDownHandler {

	public	Sprite[]	buttonImages;
	private	Image 		button;
	private string 		musicState;
	private _GC_GameOver		_GC_GameOver;

	// Use this for initialization
	void Start () {
		_GC_GameOver = FindObjectOfType (typeof(_GC_GameOver)) as _GC_GameOver;
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
			_GC_GameOver.Pause ();
			button.sprite = buttonImages [0];
			PlayerPrefs.SetString ("music", GlobalVariables.musicState);

		} else {
			GlobalVariables.musicState = "on";
			_GC_GameOver.Play();
			button.sprite = buttonImages [1];
			PlayerPrefs.SetString ("music", GlobalVariables.musicState);

		}
	}
}