using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class close : MonoBehaviour,IPointerDownHandler {
	private _GC _GC;

	void Start()
	{
		_GC = FindObjectOfType(typeof(_GC))as _GC;
	}
	public void OnPointerDown(PointerEventData ped)
	{		
		Social.ReportScore(GlobalVariables.points,BraveDragonPlayService.leaderboard_score_ranking,(bool sucess) => {});
		Social.ReportScore(_GC.coins,BraveDragonPlayService.leaderboard_coins_ranking,(bool sucess) => {});
		Debug.Log ("DEBUG: Report Score" + GlobalVariables.points.ToString() + " - " + _GC.coins.ToString() );
		SceneManager.LoadScene ("gameover");
	}

}
