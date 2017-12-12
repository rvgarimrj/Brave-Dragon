using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class continueGame : MonoBehaviour,IPointerDownHandler {
	


	private _GC _GC;


	void Start()
	{
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
	}


	public void OnPointerDown(PointerEventData ped)
	{

		_GC.ContinueGame ();
	}
		
}
