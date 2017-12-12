using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class invencible : MonoBehaviour, IPointerDownHandler {

	private _GC _GC;

	// Use this for initialization
	void Start () {
		_GC = FindObjectOfType (typeof(_GC)) as _GC;


	}

	public void OnPointerDown(PointerEventData ped)
	{
		if (!GlobalVariables.dead & !GlobalVariables.paused && !Advertisement.isShowing && !GlobalVariables.isInvencible) {
			_GC.setInvencible ();
		}

	}

}
