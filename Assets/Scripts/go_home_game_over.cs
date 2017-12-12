using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class go_home_game_over : MonoBehaviour,IPointerDownHandler  {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerDown(PointerEventData ped)
	{
	
		if (GlobalVariables.points >= PlayerPrefs.GetInt ("points")) {
			PlayerPrefs.SetInt ("points", GlobalVariables.points);

		}
		SceneManager.LoadScene ("Home");
	}
}
