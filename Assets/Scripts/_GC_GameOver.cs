using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GC_GameOver : MonoBehaviour {
	[SerializeField] private Sprite[] Sprite;

	[SerializeField]  private Image imageScore;
	[SerializeField] private Text pointsTxt, coinsTxt;
	private	AudioSource audioSource;

	void Start () {
		GlobalVariables.Playing = false;
		GlobalVariables.invencible = 0;
		GlobalVariables.musicState = PlayerPrefs.GetString ("music");
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
		//		playerAnimator = GetComponent<Animator> ();	
		//		playerAnimator.SetBool ("invencible", true);
		if (GlobalVariables.points >= PlayerPrefs.GetInt ("points")) {
			imageScore.sprite = Sprite [0];
			PlayerPrefs.SetInt ("points", GlobalVariables.points);

		} else {
			imageScore.sprite = Sprite [1];
		}
		pointsTxt.text = PlayerPrefs.GetInt ("points").ToString ();
		coinsTxt.text = PlayerPrefs.GetInt ("coins").ToString ();

	}

	// Update is called once per frame
	void Update () {

	}
	public void PlayGame ()
	{
		GlobalVariables.points = 0;
		GlobalVariables.extralifes = PlayerPrefs.GetInt ("extralifes");
		SceneManager.LoadScene("stage1");
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
