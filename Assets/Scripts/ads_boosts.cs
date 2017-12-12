using UnityEngine;
using UnityEngine.Advertisements;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ads_boosts : MonoBehaviour {

	private DateTime dateLastPlay,dateLastPlay2,dateLastPlay3,dateLastPlay4, today;
	private string temp;
	[SerializeField] private GameObject invencibleReward,coins10Reward,powerupReward,keyRewards;
	private int rand;
	private int idReward; // 0 = Invincible, 1 = 10 Coins , 2 = Powerup, 3 = One key , 4 = 50 Coins

	void Start()
	{
		
		rand = UnityEngine.Random.Range (0, 99);
		Advertisement.Initialize ("1599423", false);
	}
	void Update()
	{
		if (Advertisement.IsReady()) {
//			invencibleReward.GetComponent<Button>().interactable = false;
			ShowButtons ();
		}
	}
	void ShowButtons()
	{
		// Check for invincible video

		if (!PlayerPrefs.HasKey("datevideoinvincible")) {
			invencibleReward.GetComponent<Button>().interactable = true;
		} else {
			temp = DateTime.Now.ToString ("MM/dd/yyyy");
			//			print (PlayerPrefs.GetString ("datevideoinvincible"));
			dateLastPlay = DateTime.Parse (PlayerPrefs.GetString ("datevideoinvincible")); 
			today =  DateTime.Parse (temp);
			//			print (dateLastPlay);
			//			print (today);
			//			print(DateTime.Compare(today, dateLastPlay)); 
			if (DateTime.Compare (today, dateLastPlay) > 0) {
				// Has passed more than one day since last reward
				/*
						Less than zero -> t1 is earlier than t2.

						Zero ->  t1 is the same as t2.

						Greater than zero -> t1 is later than t2. 
						*/
				invencibleReward.GetComponent<Button>().interactable = true;
			} else if  (DateTime.Compare (today, dateLastPlay) == 0)
			{	
				// Already saw today
				invencibleReward.GetComponent<Button>().interactable = false;

			}
		}

		// Check for coins video

		if (!PlayerPrefs.HasKey("datevideocoins10")) {
			coins10Reward.GetComponent<Button>().interactable = true;
		} else {
			temp = DateTime.Now.ToString ("MM/dd/yyyy");
			dateLastPlay2 = DateTime.Parse (PlayerPrefs.GetString ("datevideocoins10")); 
			today =  DateTime.Parse (temp);
			//			print (dateLastPlay);
			//			print (today);
			//			print(DateTime.Compare(today, dateLastPlay)); 
			if (DateTime.Compare (today, dateLastPlay2) > 0) {
				// Has passed more than one day since last reward
				/*
						Less than zero -> t1 is earlier than t2.

						Zero ->  t1 is the same as t2.

						Greater than zero -> t1 is later than t2. 
						*/
				coins10Reward.GetComponent<Button>().interactable = true;
			} else if  (DateTime.Compare (today, dateLastPlay2) == 0)
			{	
				// Already saw today
				coins10Reward.GetComponent<Button>().interactable = false;

			}
		}

		// Check for powerup video

		if (!PlayerPrefs.HasKey("datevideopowerup")) {
			powerupReward.GetComponent<Button>().interactable = true;
		} else {
			temp = DateTime.Now.ToString ("MM/dd/yyyy");
			//			print (PlayerPrefs.GetString ("datevideopowerup"));
			dateLastPlay3 = DateTime.Parse (PlayerPrefs.GetString ("datevideopowerup")); 
			today =  DateTime.Parse (temp);
			//			print (dateLastPlay);
			//			print (today);
			//			print(DateTime.Compare(today, dateLastPlay)); 
			if (DateTime.Compare (today, dateLastPlay3) > 0) {
				// Has passed more than one day since last reward
				/*
						Less than zero -> t1 is earlier than t2.

						Zero ->  t1 is the same as t2.

						Greater than zero -> t1 is later than t2. 
						*/
				powerupReward.GetComponent<Button>().interactable = true;
			} else if  (DateTime.Compare (today, dateLastPlay3) == 0)
			{	
				// Already saw today
				powerupReward.GetComponent<Button>().interactable = false;

			}
		}

		// Check for one key video

		if (!PlayerPrefs.HasKey("dateonekey")) {
			keyRewards.GetComponent<Button>().interactable = true;
		} else {
			temp = DateTime.Now.ToString ("MM/dd/yyyy");
			//			print (PlayerPrefs.GetString ("datevideoinvincible"));
			dateLastPlay4 = DateTime.Parse (PlayerPrefs.GetString ("dateonekey")); 
			today =  DateTime.Parse (temp);
			//			print (dateLastPlay);
			//			print (today);
			//			print(DateTime.Compare(today, dateLastPlay)); 
			if (DateTime.Compare (today, dateLastPlay4) > 0 && rand <= 5) {
				// Has passed more than one day since last reward
				// and % is than 5% of chance
				/*
						Less than zero -> t1 is earlier than t2.

						Zero ->  t1 is the same as t2.

						Greater than zero -> t1 is later than t2. 
						*/
				keyRewards.GetComponent<Button>().interactable = true;
			} else 
				keyRewards.GetComponent<Button>().interactable = false;

		}


		// Check for 50 coins video

	}
	public void ShowAds(string zoneId)
	{

		if (string.IsNullOrEmpty (zoneId)) {
			zoneId = null;
		}
		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleShowResult;
		Advertisement.Show (zoneId, options);

	}

	public void setIdReward(int id)
	{
		idReward = id;
	}

	void HandleShowResult( ShowResult result)
	{
		switch (result) {
		case ShowResult.Failed:

			// If internet failed

			break;
		case ShowResult.Finished:
			switch (idReward) {
			case 0:
				GlobalVariables.invencible++;
				GlobalFunctions.achieviments ("adds");

				if (!PlayerPrefs.HasKey ("datevideoinvincible")) {
					PlayerPrefs.SetString ("datevideoinvincible", DateTime.Now.ToString ("MM/dd/yyyy"));
				}
				break;
			case 1:
				int coins;
				coins = PlayerPrefs.GetInt ("coins");
				coins += 10;
				GlobalFunctions.achieviments ("adds");

				PlayerPrefs.SetInt ("coins", coins);
				if (!PlayerPrefs.HasKey ("datevideocoins10")) {
					PlayerPrefs.SetString ("datevideocoins10", DateTime.Now.ToString ("MM/dd/yyyy"));
				}
				break;
			case 2:
				GlobalVariables.powerup++;
				GlobalFunctions.achieviments ("adds");

				if (!PlayerPrefs.HasKey ("datevideopowerup")) {
					PlayerPrefs.SetString ("datevideopowerup", DateTime.Now.ToString ("MM/dd/yyyy"));
				}
				break;
			case 3:
				GlobalVariables.keys = PlayerPrefs.GetInt ("keys");
				GlobalVariables.keys++;
				GlobalFunctions.achieviments ("adds");

				PlayerPrefs.SetInt ("keys",GlobalVariables.keys);
				if (!PlayerPrefs.HasKey ("dateonekey")) {
					PlayerPrefs.SetString ("dateonekey", DateTime.Now.ToString ("MM/dd/yyyy"));
				}
				print ("Boost: " + GlobalVariables.keys);
				break;
			}
			break;
		case ShowResult.Skipped:

			break;
		}
	}
}
