using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class music : MonoBehaviour,IPointerDownHandler {

	public	Sprite[]	buttonImages;
	private	Image 		button;
	private string 		musicState;
	public GameObject redPlayer, greenPlayer, bluePlayer, yellowPlayer;
	private _GC _GC;

	// Use this for initialization
	void Start () {
		button = GetComponent<Image> ();
		GlobalVariables.musicState = PlayerPrefs.GetString ("music");
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
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
		if (!GlobalVariables.paused) {
			if (GlobalVariables.musicState == "on") {
				GlobalVariables.musicState = "off";
				_GC.PauseSound ();
//				if (PlayerPrefs.GetString ("playercolor") == "red") {
//					redPlayer.SendMessage ("PauseSound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "green") {
//					greenPlayer.SendMessage ("PauseSound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "blue") {
//					bluePlayer.SendMessage ("PauseSound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "yellow") {
//					yellowPlayer.SendMessage ("PauseSound", SendMessageOptions.DontRequireReceiver);
//				}
				button.sprite = buttonImages [0];
				PlayerPrefs.SetString ("music", GlobalVariables.musicState);

			} else {
				GlobalVariables.musicState = "on";
				_GC.PlaySound ();
//				if (PlayerPrefs.GetString ("playercolor") == "red") {
//					redPlayer.SendMessage ("PlaySound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "green") {
//					greenPlayer.SendMessage ("PlaySound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "blue") {
//					bluePlayer.SendMessage ("PlaySound", SendMessageOptions.DontRequireReceiver);
//				}
//				if (PlayerPrefs.GetString ("playercolor") == "yellow") {
//					yellowPlayer.SendMessage ("PlaySound", SendMessageOptions.DontRequireReceiver);
//				}
				button.sprite = buttonImages [1];
				PlayerPrefs.SetString ("music", GlobalVariables.musicState);

			}
		}
	}
}
