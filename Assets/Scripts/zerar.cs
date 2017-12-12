using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class zerar : MonoBehaviour,IPointerDownHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData ped)
	{
		PlayerPrefs.SetInt ("points", 0);
		PlayerPrefs.SetInt ("coins",0);
		PlayerPrefs.SetInt ("invencible", 0);
		// PlayerPrefs.SetInt ("redinvencibletime", 5);
		// PlayerPrefs.SetInt ("greeninvencibletime", 5);
		// PlayerPrefs.SetInt ("blueinvencibletime", 5);
		// PlayerPrefs.SetInt ("yellowinvencibletime", 5);
		PlayerPrefs.SetInt ("extralifes", 2);	

		PlayerPrefs.SetString ("redshoot","playerShoot1");
		PlayerPrefs.SetString ("greenshoot","playerShoot2");
		PlayerPrefs.SetString ("blueshoot","playerShoot4");
		PlayerPrefs.SetString ("yellowshoot","playerShoot3");

		PlayerPrefs.DeleteKey("datevideoinvincible");
		PlayerPrefs.DeleteKey("datevideocoins10");
		PlayerPrefs.DeleteKey("dateonekey");
		PlayerPrefs.DeleteKey("datevideopowerup");
		PlayerPrefs.DeleteKey("firstplay");
		PlayerPrefs.DeleteKey("points");
		PlayerPrefs.DeleteKey("invencible");
		PlayerPrefs.DeleteKey("timeplaying");
		PlayerPrefs.DeleteKey("keys");

//		PlayerPrefs.SetInt ("greenenabled", 0);
//		PlayerPrefs.SetInt ("yellowenabled", 0);
//		PlayerPrefs.SetInt ("blueenabled", 0);

		PlayerPrefs.SetInt ("greenenabled", 1);
		PlayerPrefs.SetInt ("yellowenabled", 1);
		PlayerPrefs.SetInt ("blueenabled", 1);

		PlayerPrefs.SetInt ("redpower", 1);
		PlayerPrefs.SetInt ("redspeed", 1);
		PlayerPrefs.SetInt ("redshoot", 1);
		PlayerPrefs.SetInt ("redinvincible", 1);

		PlayerPrefs.SetInt ("greenpower", 2);
		PlayerPrefs.SetInt ("greenspeed", 2);
		PlayerPrefs.SetInt ("greenshoot", 2);
		PlayerPrefs.SetInt ("greeninvincible", 1);

		PlayerPrefs.SetInt ("yellowpower", 2);
		PlayerPrefs.SetInt ("yellowspeed", 2);
		PlayerPrefs.SetInt ("yellowshoot", 3);
		PlayerPrefs.SetInt ("yellowinvincible", 1);

		PlayerPrefs.SetInt ("bluepower", 2);
		PlayerPrefs.SetInt ("bluespeed", 2);
		PlayerPrefs.SetInt ("blueshoot", 4);
		PlayerPrefs.SetInt ("blueinvincible", 4);




	}
}
