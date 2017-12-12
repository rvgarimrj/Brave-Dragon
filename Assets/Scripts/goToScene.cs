using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToScene : MonoBehaviour {

	public GameObject 	red, green, yellow, blue,redLeft, redRight, greenLeft, 
						greenRight, yellowLeft, yellowRight, blueLeft, blueRight,upgradeButton, 
						playRed,playGreen,playYellow,playBlue, redPanel, greenPanel, yellowPanel, bluePanel; 
//	public Button 		redLeft, redRight, greenLeft, greenRight, yellowLeft, yellowRight, blueLeft, blueRight, playRed,playGreen,playYellow,playBlue; 
	private Main Main;

	void Start()
	{
//		Main = FindObjectOfType (typeof(Main)) as Main;
	}
	public void toScene(string scene)
	{
//		Main.Stop ();
		GlobalVariables.points = 0;
		SceneManager.LoadScene(scene);
	}

	public void play(string color)
	{
		GlobalVariables.playerColor = color;
		PlayerPrefs.SetString ("playercolor", color);
		GlobalVariables.extralifes = PlayerPrefs.GetInt ("extralifes");
		SceneManager.LoadScene ("stage1");
	}

	public void next(string color)
	{
		switch (color) {
		case "Red":
			blueLeft.SetActive (false);
			blueRight.SetActive (false);
			playBlue.SetActive (false);
			blue.SetActive (false);
			bluePanel.SetActive (false);
			upgradeButton.SetActive (false);
			redLeft.SetActive (true);
			redRight.SetActive (true);
			playRed.SetActive (true);
			red.SetActive (true);
			redPanel.SetActive (true);

			break;
		case "Green":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			playRed.SetActive (false);
			red.SetActive (false);
			redPanel.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);
			if (PlayerPrefs.GetInt ("greenenabled") == 0) {
				upgradeButton.SetActive (true);
				playGreen.SetActive (false);
			} else {
				playGreen.SetActive (true);
				upgradeButton.SetActive (false);
			}

			green.SetActive (true);
			greenPanel.SetActive (true);
			break;

		case "Yellow":
			greenLeft.SetActive (false);
			greenRight.SetActive (false);
			playGreen.SetActive (false);
			green.SetActive (false);
			greenPanel.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);
			if (PlayerPrefs.GetInt ("yellowenabled") == 0) {
				upgradeButton.SetActive (true);
				playYellow.SetActive (false);
			} else {
				playYellow.SetActive (true);
				upgradeButton.SetActive (false);
			}
				
			yellow.SetActive (true);
			yellowPanel.SetActive (true);

			break;

		case "Blue":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			playYellow.SetActive (false);
			yellow.SetActive (false);
			yellowPanel.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
			if (PlayerPrefs.GetInt ("blueenabled") == 0) {
				upgradeButton.SetActive (true);
				playBlue.SetActive (false);
			} else {
				playBlue.SetActive (true);
				upgradeButton.SetActive (false);
			}
			blue.SetActive (true);
			bluePanel.SetActive (true);
			break;
		}

	}

	public void previous(string color)
	{
		switch (color) {
		case "Red":
			greenLeft.SetActive (false);
			greenRight.SetActive (false);
			playGreen.SetActive (false);
			green.SetActive (false);
			greenPanel.SetActive (false);
			upgradeButton.SetActive (false);
			redLeft.SetActive (true);
			redRight.SetActive (true);
			playRed.SetActive (true);
			red.SetActive (true);
			redPanel.SetActive (true);

			break;

		case "Green":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			playYellow.SetActive (false);
			yellow.SetActive (false);
			yellowPanel.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);
			if (PlayerPrefs.GetInt ("greenenabled") == 0) {
				upgradeButton.SetActive (true);
				playGreen.SetActive (false);
			} else {
				playGreen.SetActive (true);
				upgradeButton.SetActive (false);
			}

			green.SetActive (true);
			greenPanel.SetActive (true);
			break;

		case "Yellow":
			blueLeft.SetActive (false);
			blueRight.SetActive (false);
			playBlue.SetActive (false);
			blue.SetActive (false);
			bluePanel.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);
			if (PlayerPrefs.GetInt ("yellowenabled") == 0) {
				upgradeButton.SetActive (true);
				playYellow.SetActive (false);
			} else {
				playYellow.SetActive (true);
				upgradeButton.SetActive (false);
			}
			yellow.SetActive (true);
			yellowPanel.SetActive (true);
			break;

		case "Blue":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			playRed.SetActive (false);
			red.SetActive (false);
			redPanel.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
			if (PlayerPrefs.GetInt ("blueenabled") == 0) {
				upgradeButton.SetActive (true);
				playBlue.SetActive (false);
			} else {
				playBlue.SetActive (true);
				upgradeButton.SetActive (false);
			}
			blue.SetActive (true);
			bluePanel.SetActive (true);
			break;
		}
	}
}
