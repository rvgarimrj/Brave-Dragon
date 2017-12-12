using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class googlePlayService : MonoBehaviour {
	public GameObject btnLogin, btnRanking, btnCoins, btnConqueer;
	// Use this for initialization
	void Start () {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
//		if (Social.localUser.authenticated == false) {
			loginGoogle ();
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loginGoogle()
	{
		
		Social.localUser.Authenticate ((bool sucesso) => {
			if(sucesso)
			{
				Debug.Log("DEBUG: Google Play Services: Logado");
				authenticated(true);

			}
			else{
				authenticated(false);

				Debug.Log("DEBUG: Google Play Services: Erro");
			}
		});
	}
	void authenticated(bool auth)
	{
		if (auth) {
			Debug.Log("DEBUG: Google Play Services: Autenticado");
			btnRanking.SetActive (true);
			btnConqueer.SetActive (true);
			btnCoins.SetActive (true);
			btnLogin.SetActive (false);
		} else {
			Debug.Log("DEBUG: Google Play Services: Não autenticado");
			btnRanking.SetActive (false);
			btnConqueer.SetActive (false);
			btnCoins.SetActive (false);
			btnLogin.SetActive (true);

		}
	}

	public void showRanking()
	{
		PlayGamesPlatform.Instance.ShowLeaderboardUI (BraveDragonPlayService.leaderboard_score_ranking);
		Debug.Log("DEBUG: Google Play Services: Chamando Ranking");

	}

	public void showCoins()
	{
		PlayGamesPlatform.Instance.ShowLeaderboardUI (BraveDragonPlayService.leaderboard_coins_ranking);
		Debug.Log("DEBUG: Google Play Services: Chamando Ranking Coins");
	}

	public void showConquistas()
	{
		Social.ShowAchievementsUI ();
		Debug.Log("DEBUG: Google Play Services: Chamando Achieviments");
	}
}
