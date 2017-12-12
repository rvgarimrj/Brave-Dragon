using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class _GC : MonoBehaviour {
	[SerializeField] private Text Keys_Txt;
	public	Text			pointText,extraLifeTxt,Coins_Txt,Diamond_Txt,Invencible_Txt,invincibleTimeTxt;
	public	int 			invincibleCountDown,points,extraLifes,coins,diamonds,aux_points, aux_diamonds, aux_coins,invencible,aux_invencible,HP;
	public  Transform 		barraHP;
	public GameObject		Layer2,Layer3,Layer4,Layer5,Layer6,btn_Invencible,gameOverTxT,invenciblePanel;
	private	Vector3 		theScale;
	public 	float			scale,playerSpeed,enemySpeed,playerShootSpeed,enemyShootSpeed,timeForShooting,timeValue;
	public 	GameObject		redPlayer,greenPlayer,bluePlayer,yellowPlayer,spawnPlayer;
//	private	GameObject 		actualPlayer;	
//	private	Player 			Player;
	private	float			percLife,speedLayer;
	[SerializeField] private AudioClip[] soundTrack;
	private AudioSource soundTrackActual;
	private ads_playing ads_playing;
	public  string playercolor;
	private fade fade;

	[SerializeField] private Sprite[] 	countdown;
	[SerializeField] private Image 		imageCountDown;
	[SerializeField] private GameObject	panelCountDown,showKeyAdds,showWatchedKeyVideo;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private int timeDivision,timeForAdds;

	private int i,gameTime;



	// Use this for initialization
	void Start () {
		GlobalVariables.killedEnemies = PlayerPrefs.GetInt ("enemies");
//		print ("GC: " + GlobalVariables.keys);
		if (Social.localUser.authenticated == true && PlayerPrefs.GetInt ("playonce") == 0) {
			Social.ReportProgress (BraveDragonPlayService.achievement_played_brave_dragon, 100f, (bool succes) => {
			});
			PlayerPrefs.SetInt ("playonce", 1);
		}
		GlobalVariables.Playing = true;
		GlobalVariables.showAdds = false;
		ads_playing = FindObjectOfType (typeof(ads_playing)) as ads_playing;

		soundTrackActual = GetComponent<AudioSource> ();
		gameTime = 0;
		enemySpeed = 0;
		playerSpeed = 0;
		StartCoroutine ("GameTime");
		theScale = barraHP.localScale;
		scale = theScale.x;
		fade = FindObjectOfType (typeof(fade)) as fade;
		fade.fadeEffect ("fadeIn");
		StartHPBar ();
//		points = aux_points = PlayerPrefs.GetInt ("points", points);
		coins = aux_coins = PlayerPrefs.GetInt ("coins",coins);
		diamonds = aux_diamonds = PlayerPrefs.GetInt ("diamonds",diamonds);
		invencible = GlobalVariables.invencible;
		Coins_Txt.text = aux_coins.ToString ();
		Diamond_Txt.text = aux_diamonds.ToString ();
		pointText.text = GlobalVariables.points.ToString ();
		if ( invencible > 0) {
			Invencible_Txt.text = aux_invencible.ToString ();
			btn_Invencible.SetActive (true);
//			print (GlobalVariables.invencible);
		}

		if(GlobalVariables.playerColor == "red")
		{
//			invencible = aux_invencible = PlayerPrefs.GetInt ("redinvencible", invencible);
			soundTrackActual.clip = soundTrack[0];
			GlobalVariables.actualPlayer = Instantiate (redPlayer);
			GlobalVariables.actualPlayer.name = redPlayer.name;
			GlobalVariables.actualPlayer.transform.position = spawnPlayer.transform.position;

//			redPlayer.SetActive (true);
//			greenPlayer.SetActive (false);
//			bluePlayer.SetActive (false);
//			yellowPlayer.SetActive (false);


		}
		if(GlobalVariables.playerColor == "green")
		{
//			invencible = aux_invencible = PlayerPrefs.GetInt ("greeninvencible", invencible);
			soundTrackActual.clip = soundTrack[1];
			GlobalVariables.actualPlayer = Instantiate (greenPlayer);
			GlobalVariables.actualPlayer.name = greenPlayer.name;
			GlobalVariables.actualPlayer.transform.position = spawnPlayer.transform.position;
//			redPlayer.SetActive (false);
//			greenPlayer.SetActive (true);
//			bluePlayer.SetActive (false);
//			yellowPlayer.SetActive (false);

		}

		if(GlobalVariables.playerColor == "blue")
		{
//			invencible = aux_invencible = PlayerPrefs.GetInt ("blueinvencible", invencible);
			soundTrackActual.clip = soundTrack[2];
			GlobalVariables.actualPlayer = Instantiate (bluePlayer);
			GlobalVariables.actualPlayer.name = bluePlayer.name;
			GlobalVariables.actualPlayer.transform.position = spawnPlayer.transform.position;
//			redPlayer.SetActive (false);
//			greenPlayer.SetActive (false);
//			bluePlayer.SetActive (true);
//			yellowPlayer.SetActive (false);

		}
		if(GlobalVariables.playerColor == "yellow")
		{
//			invencible = aux_invencible = PlayerPrefs.GetInt ("yelloinvencible", invencible);
			soundTrackActual.clip = soundTrack[3];
			GlobalVariables.actualPlayer = Instantiate (yellowPlayer);
			GlobalVariables.actualPlayer.name = yellowPlayer.name;
			GlobalVariables.actualPlayer.transform.position = spawnPlayer.transform.position;
//			redPlayer.SetActive (false);
//			greenPlayer.SetActive (false);
//			bluePlayer.SetActive (false);
//			yellowPlayer.SetActive (true);

		}

		extraLifes = GlobalVariables.extralifes;
		extraLifeTxt.text = GlobalVariables.extralifes.ToString ();
		soundTrackActual.loop = true;
		if (GlobalVariables.musicState == "on") {
			PlaySound ();
		}
//		print ("GC:  " + GlobalVariables.extralifes);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (invenciblePanel.activeInHierarchy) {
			invincibleTimeTxt.text = invincibleCountDown.ToString ();
		}
		pointText.text = GlobalVariables.points.ToString ();
		extraLifeTxt.text = GlobalVariables.extralifes.ToString ();
		Coins_Txt.text = coins.ToString ();
		Diamond_Txt.text = diamonds.ToString ();
		Invencible_Txt.text = invencible.ToString ();
		if (diamonds > aux_diamonds) {
			PlayerPrefs.SetInt ("diamonds", diamonds);
		}
		if (coins > aux_coins) {
			PlayerPrefs.SetInt ("coins", coins);
		}
//		if (points > aux_points) {
//			PlayerPrefs.SetInt ("points", points);
//		}
		if (invencible > 0) {
			btn_Invencible.SetActive (true);
			Invencible_Txt.text = invencible.ToString ();

		} else {
			btn_Invencible.SetActive(false);
		}

	}
	public void setPanel(bool show)
	{
		invenciblePanel.SetActive (show);
	}
	public void setInvencible()
	{
		GlobalVariables.actualPlayer.SendMessage("invencible", SendMessageOptions.DontRequireReceiver);

	}
	public void PlayerFire()
	{
		GlobalVariables.actualPlayer.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);

	}
	IEnumerator GameTime()
	{
		yield return new WaitForSeconds (1);
		gameTime++;
//		print (gameTime);

//		if (gameTime == 30) {
			
//			print (gameTime);
//		}
		GlobalVariables.timePlaying = gameTime;
//		print (GlobalVariables.timePlaying);
		if (gameTime % timeDivision == 0) {
//			print ("time division");
			GlobalVariables.actualPlayer.SendMessage("SpeedUp", 0.1f, SendMessageOptions.DontRequireReceiver);
			GlobalVariables.enemySpeed += 0.2f;
			GlobalVariables.timeForShooting += 0.2f;
			GlobalVariables.timeForChangeSide += 0.1f;
			GlobalVariables.shootForce += 50;
			GlobalVariables.percentualOfChangeSide += 5;
			GlobalVariables.percentualOfShooting += 5;
			speedLayer += 0.2f;
			Layer2.SendMessage ("speedup", 0.2f, SendMessageOptions.DontRequireReceiver);
			Layer3.SendMessage ("speedup", 0.2f, SendMessageOptions.DontRequireReceiver);
			Layer4.SendMessage ("speedup", speedLayer + 0.2f, SendMessageOptions.DontRequireReceiver);
			Layer5.SendMessage ("speedup", speedLayer + 0.3f, SendMessageOptions.DontRequireReceiver);
			Layer6.SendMessage ("speedup", speedLayer + 0.2f, SendMessageOptions.DontRequireReceiver);
		}
		if (GlobalVariables.Playing) {
			
			StartCoroutine ("GameTime");
		}
	}
	IEnumerator Died()
	{
		
		gameOverTxT.SetActive (true);
//		print (GlobalVariables.timePlaying);
//		print (PlayerPrefs.GetInt ("firstplay"));
		if (PlayerPrefs.GetInt ("firstplay") == 0) {
			// First time playing show key adds id = 0
//			print("primeira vez que joga");
			ads_playing.setId(0);
			showKeyAdds.SetActive (true);
			yield return null;
		}else if (gameTime <= timeForAdds ) {
//			PlayerPrefs.SetInt ("timeplaying", GlobalVariables.timePlaying); 
//			print ("morreu abaixo de 30s");
			showKeyAdds.SetActive (true);
			yield return null;
		} else 	if (PlayerPrefs.GetInt("keys") > 0) {
			// User watched keys adds at boosts scene
//			print("assistiu ao video no boost");
			showWatchedKeyVideo.SetActive (true);
			Keys_Txt.text = PlayerPrefs.GetInt("keys").ToString() + " key(s) left";
			yield return null;
//		} else if (PlayerPrefs.GetInt ("keys") > 0) {
//			// User has bought some keys or saw some video, let him use them
//			yield return null;
		} else 	
//			if (GlobalVariables.timePlaying > timeForAdds && PlayerPrefs.GetInt ("keys") == 0 && PlayerPrefs.GetInt ("firstplay") == 1 && GlobalVariables.keys == 0)
		{
//			print ("morreu ");
			if (Social.localUser.authenticated == true) {
				Social.ReportScore (GlobalVariables.points, BraveDragonPlayService.leaderboard_score_ranking, (bool sucess) => {
				});
				Social.ReportScore (coins, BraveDragonPlayService.leaderboard_coins_ranking, (bool sucess) => {
				});
				Debug.Log ("DEBUG: Report Score" + GlobalVariables.points.ToString () + " - " + coins.ToString ());
			}

			yield return new WaitForSeconds (3);
			SceneManager.LoadScene ("gameover");
		}

		// Use keys bought throught IAP
		//		if (GlobalVariables.keys > 0 && PlayerPrefs.GetInt("keys") > 0) {
		//			// User watched keys adds at boosts scene
		//			showWatchedKeyVideo.SetActive (true);
		//			Keys_Txt.text = PlayerPrefs.GetInt("keys").ToString() + " keys";
		//			yield return null;
		//		}


	}

	public void GameOver()
	{
		//		Destroy (this.gameObject);
		GlobalVariables.Playing = false;
		StartCoroutine("Died");

	}
	public void StartHPBar()
	{
		// Set HP Bar to 100% and save original scale


		percLife = 1;
		theScale.x = percLife * scale;
		barraHP.localScale = theScale;
	}
	public void PauseSound()
	{
		soundTrackActual.Pause ();
	}

	public void PlaySound()
	{
		soundTrackActual.Play ();
	}

	public void StopSound()
	{
		soundTrackActual.Stop ();
	}
	public void UpdateHPBar(float perc)
	{
		// Updates the size of HP Bar
		percLife = perc;
		theScale.x = percLife * scale;
		barraHP.localScale = theScale;

	}

	public void PauseGame()
	{
		GlobalVariables.paused = true;
		if (GlobalVariables.musicState == "on") {
			PauseSound ();
		}
		Time.timeScale = 0;
		i = 0;
		pausePanel.SetActive (true);
	}

	IEnumerator ContinueCount()
	{
		yield return new WaitForSeconds (1);
		i++;



		if (i <= 4) {
			imageCountDown.sprite = countdown [i];

			StartCoroutine ("ContinueCount");

		} else {
			panelCountDown.SetActive (false);
			GlobalVariables.paused = false;
			if (GlobalVariables.musicState == "on") {
				PlaySound ();
			}

		}

	}

	public void ContinueGame()
	{
		Time.timeScale = 1;
		imageCountDown.sprite = countdown [i];
		pausePanel.SetActive (false);

		panelCountDown.SetActive (true);
		StartCoroutine ("ContinueCount");
	}

	public void speedup ()
	{
		Layer2.SendMessage ("speedup", 5, SendMessageOptions.DontRequireReceiver);
		Layer3.SendMessage ("speedup", 5, SendMessageOptions.DontRequireReceiver);
		Layer4.SendMessage ("speedup", 7, SendMessageOptions.DontRequireReceiver);
		Layer5.SendMessage ("speedup", 8, SendMessageOptions.DontRequireReceiver);
		Layer6.SendMessage ("speedup", 7, SendMessageOptions.DontRequireReceiver);
	}

	public void speeddown()
	{
		Layer2.SendMessage ("speeddown",5, SendMessageOptions.DontRequireReceiver);
		Layer3.SendMessage ("speeddown",5,SendMessageOptions.DontRequireReceiver);
		Layer4.SendMessage ("speeddown",7, SendMessageOptions.DontRequireReceiver);
		Layer5.SendMessage ("speeddown",8, SendMessageOptions.DontRequireReceiver);
		Layer6.SendMessage ("speeddown",7, SendMessageOptions.DontRequireReceiver);
	}
}
