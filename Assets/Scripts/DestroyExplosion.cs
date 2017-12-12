using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

	public	float		timeLife;
	private	float tempTime;
	private string	sound;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		sound = PlayerPrefs.GetString ("music");
		if (sound == "on") {
			audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		tempTime += Time.deltaTime;
		if (tempTime >= timeLife) {
			Destroy (this.gameObject);
		}
	}
}
