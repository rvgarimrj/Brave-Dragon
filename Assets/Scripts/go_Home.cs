using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class go_Home : MonoBehaviour,IPointerDownHandler  {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData ped)
	{
		if (!GlobalVariables.dead & !GlobalVariables.paused && !Advertisement.isShowing) 
			{
				if (GlobalVariables.points >= PlayerPrefs.GetInt ("points")) {
					PlayerPrefs.SetInt ("points", GlobalVariables.points);

				}
				GlobalVariables.invencible = 0;
				SceneManager.LoadScene ("Home");
			}
	}
}
