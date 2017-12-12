using UnityEngine;
using UnityEngine.Advertisements;
using System;
public class ads : MonoBehaviour {

	private DateTime dateLastPlay,dateLastPlay2,dateLastPlay3, today;
	private string temp;
	[SerializeField] private GameObject invencibleReward,coins10Reward,powerupReward;

	private int idReward; // 0 = Invencible, 1 = 10 Coins , 2 = Powerup, 3 = One key 
	void Start()
	{
		Advertisement.Initialize ("1599423", false);
	}
	void Update()
	{
		if (Advertisement.IsReady() && GlobalVariables.showAdds) {
			ShowButtons ();
		}
	}
	void ShowButtons()
	{
		// Check for invincible video
		
		if (!PlayerPrefs.HasKey("datevideoinvincible")) {
			invencibleReward.SetActive (true);
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
				invencibleReward.SetActive (true);
			} else if  (DateTime.Compare (today, dateLastPlay) == 0)
			{	
				// Already saw today
				invencibleReward.SetActive (false);

			}
		}

		// Check for coins video

		if (!PlayerPrefs.HasKey("datevideocoins10")) {
			coins10Reward.SetActive (true);
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
				coins10Reward.SetActive (true);
			} else if  (DateTime.Compare (today, dateLastPlay2) == 0)
			{	
				// Already saw today
				coins10Reward.SetActive (false);

			}
		}

		// Check for powerup video

		if (!PlayerPrefs.HasKey("datevideopowerup")) {
			powerupReward.SetActive (true);
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
				powerupReward.SetActive (true);
			} else if  (DateTime.Compare (today, dateLastPlay3) == 0)
			{	
				// Already saw today
				powerupReward.SetActive (false);

			}
		}

		// 

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
			}
		break;
		case ShowResult.Skipped:

		break;
		}
	}
}
