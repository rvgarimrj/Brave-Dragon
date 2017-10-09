using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
	private	Animator	playerAnimator;

	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();	
		playerAnimator.SetBool ("invencible", true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
