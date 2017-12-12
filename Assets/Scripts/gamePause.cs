using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class gamePause : MonoBehaviour,IPointerDownHandler {

	private _GC _GC;


	void Start()
	{
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
	}


	public void OnPointerDown(PointerEventData ped)
	{
		if (!GlobalVariables.paused && !GlobalVariables.dead && !Advertisement.isShowing) {
			_GC.PauseGame ();
		}
	}


}
