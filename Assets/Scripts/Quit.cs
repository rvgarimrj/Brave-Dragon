﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Quit : MonoBehaviour,IPointerDownHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData ped)
	{
		Application.Quit ();
	}
}
