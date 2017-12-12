using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {
	private	Animator	playerAnimator;
	[SerializeField] private	AudioSource audioSource;
	private string sound;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		GlobalVariables.musicState = PlayerPrefs.GetString ("music");
		if (GlobalVariables.musicState == "on") {
			Play ();
		} else {
			Pause ();
		}
//		playerAnimator = GetComponent<Animator> ();	
//		playerAnimator.SetBool ("invencible", true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause()
	{
		audioSource.Pause ();

	}

	public void Play()
	{
		audioSource.Play ();

	}
}
