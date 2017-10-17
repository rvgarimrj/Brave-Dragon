using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GC : MonoBehaviour {
	public	Text			pointText,extraLifeTxt;
	public	int 			points;
	public  Transform 		barraHP;
	private	Vector3 		theScale;
	private	float			scale;
	public 	GameObject[]	playerGO;
	private	GameObject 		actualPlayer;	
	private	Player 			Player;
	private	float			percLife;
	public int 			extraLifes;

	// Use this for initialization
	void Start () {


		Player = FindObjectOfType (typeof(Player)) as Player;
		theScale = barraHP.localScale;
		scale = theScale.x;

		StartHPBar ();

		PlayerPrefs.SetString("playercolor","red");

		if(PlayerPrefs.GetString("playercolor") == "red")
		{
//			actualPlayer = Instantiate (playerGO [0]) as GameObject;	

		}

		extraLifes = Player.extraLifes;
		extraLifeTxt.text = extraLifes.ToString ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		pointText.text = points.ToString ();
		extraLifeTxt.text = extraLifes.ToString ();
	}

	public void StartHPBar()
	{
		// Set HP Bar to 100% and save original scale


		percLife = 1;
		theScale.x = percLife * scale;
		barraHP.localScale = theScale;
	}

	public void UpdateHPBar(float perc)
	{
		// Updates the size of HP Bar
		percLife = perc;
		theScale.x = percLife * scale;
		barraHP.localScale = theScale;

	}
}
