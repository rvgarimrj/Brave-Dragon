using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class virtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public	Sprite[]	buttonImages;
	private	Image 		button;
	private	_GC _GC;


	// Use this for initialization
	void Start () {
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
		button = GetComponent<Image> ();

	}
	
	public void OnPointerDown(PointerEventData ped)
	{
			_GC.PlayerFire ();
	}

	public void OnPointerUp(PointerEventData ped)
	{
		button.sprite = buttonImages [0];
	}

}
