using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public static class GlobalFunctions {
	
	public static void achieviments(string idAchieve)
	{
		if (Social.localUser.authenticated) {
			switch (idAchieve) {
			case "adds":
				int qtd_adds;
				qtd_adds = PlayerPrefs.GetInt ("adds");
				qtd_adds++;
				PlayerPrefs.SetInt ("adds", qtd_adds);
				if (qtd_adds == 10) {
					Social.ReportProgress (BraveDragonPlayService.achievement_watched_10_boosts_videos, 100f, (bool sucess) => {
					});
				}
				if (qtd_adds == 20) {
					Social.ReportProgress (BraveDragonPlayService.achievement_watched_20_boosts_videos, 100f, (bool sucess) => {
					});
				}
				if (qtd_adds == 30) {
					Social.ReportProgress (BraveDragonPlayService.achievement_watched_30_boosts_videos, 100f, (bool sucess) => {
					});
				}
				break;
			case "greenplayerunlock":
				Social.ReportProgress(BraveDragonPlayService.achievement_unlocked_iddyra,100f, (bool sucess) => {});
				break;
			case "yellowplayerunlock":
				Social.ReportProgress(BraveDragonPlayService.achievement_unlocked_burug,100f, (bool sucess) => {});
				break;
			case "blueplayerunlock":
				Social.ReportProgress(BraveDragonPlayService.achievement_unlocked_oldriss,100f, (bool sucess) => {});
				break;
			case "enemy":
				GlobalVariables.killedEnemies++;
				PlayerPrefs.SetInt ("enemies", GlobalVariables.killedEnemies);
				if (GlobalVariables.killedEnemies >= 50 && PlayerPrefs.GetInt ("50enemies") == 0) {
					Social.ReportProgress (BraveDragonPlayService.achievement_killed_50_enemies, 100f, (sucess) => {
					});
					PlayerPrefs.SetInt ("50enemies",1);
				}
				if (GlobalVariables.killedEnemies >= 100 && PlayerPrefs.GetInt ("100enemies") == 0) {
					Social.ReportProgress (BraveDragonPlayService.achievement_killed_100_enemies, 100f, (sucess) => {
					});
					PlayerPrefs.SetInt ("100enemies",1);
				}
				break;
			case "powerup":
				GlobalVariables.qtdPowerups++;
				if (GlobalVariables.qtdPowerups == 4 && PlayerPrefs.GetInt("4powerups") == 0) {
					Social.ReportProgress (BraveDragonPlayService.achievement_got_4_powerups, 100f, (bool sucess) => {
					});
					PlayerPrefs.SetInt("4powerups",1);
				
				}
				break;
			case "points":
				if (GlobalVariables.points >= 1000 && PlayerPrefs.GetInt("1000points") == 0 ) {
					Social.ReportProgress (BraveDragonPlayService.achievement_made_1000_points, 100f, (bool sucess) => {
					});
					PlayerPrefs.SetInt ("1000points", 1);
				}
				if (GlobalVariables.points >= 5000 && PlayerPrefs.GetInt("5000points") == 0 ) {
					Social.ReportProgress (BraveDragonPlayService.achievement_made_1000_points, 100f, (bool sucess) => {
					});
					PlayerPrefs.SetInt ("5000points", 1);
				}
				break;
			}
		}
	}
}
