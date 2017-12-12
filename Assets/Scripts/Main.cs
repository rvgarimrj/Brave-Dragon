using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	private	Animator	playerAnimator;
	private	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		GlobalVariables.musicState = PlayerPrefs.GetString ("music");
		GlobalVariables.points = 0;
		if (string.IsNullOrEmpty (GlobalVariables.musicState)) {
			PlayerPrefs.SetString ("music", "on");
			GlobalVariables.musicState = "on";
		}

		audioSource = GetComponent<AudioSource> ();
		if (GlobalVariables.musicState == "on") {
			Play ();
		} else {
			Pause ();
		}
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

	public void Stop()
	{
		audioSource.Stop ();
	}

}
