using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

	public	float		timeLife;
	private	float tempTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		tempTime += Time.deltaTime;
		if (tempTime >= timeLife) {
			Destroy (this.gameObject);
		}
	}
}
