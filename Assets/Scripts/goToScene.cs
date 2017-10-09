using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToScene : MonoBehaviour {

	public GameObject 	red, green, yellow, blue,redLeft, redRight, greenLeft, greenRight, yellowLeft, yellowRight, blueLeft, blueRight, playRed,playGreen,playYellow,playBlue; 
//	public Button 		redLeft, redRight, greenLeft, greenRight, yellowLeft, yellowRight, blueLeft, blueRight, playRed,playGreen,playYellow,playBlue; 

	public void toScene(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void play(string color)
	{
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

			redLeft.SetActive (true);
			redRight.SetActive (true);
			playRed.SetActive (true);
			red.SetActive (true);

			break;
		case "Green":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			playRed.SetActive (false);
			red.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);
			playGreen.SetActive (true);
			green.SetActive (true);
			break;

		case "Yellow":
			greenLeft.SetActive (false);
			greenRight.SetActive (false);
			playGreen.SetActive (false);
			green.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);
			playYellow.SetActive (true);
			yellow.SetActive (true);
			break;

		case "Blue":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			playYellow.SetActive (false);
			yellow.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
			playBlue.SetActive (true);
			blue.SetActive (true);
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

			redLeft.SetActive (true);
			redRight.SetActive (true);
			playRed.SetActive (true);
			red.SetActive (true);
			break;

		case "Green":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			playYellow.SetActive (false);
			yellow.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);
			playGreen.SetActive (true);
			green.SetActive (true);
			break;

		case "Yellow":
			blueLeft.SetActive (false);
			blueRight.SetActive (false);
			playBlue.SetActive (false);
			blue.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);
			playYellow.SetActive (true);
			yellow.SetActive (true);
			break;

		case "Blue":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			playRed.SetActive (false);
			red.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
			playBlue.SetActive (true);
			blue.SetActive (true);
			break;
		}
	}
}
