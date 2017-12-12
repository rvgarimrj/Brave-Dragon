using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ads_playing : MonoBehaviour {
	[SerializeField] private GameObject showKeyAdds,gameOverTxt,showWatchedKeyVideo;
	private int idAdd;
	// Use this for initialization
	void Start () {
		Advertisement.Initialize ("1599423",false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setId(int id)
	{
		idAdd = id;
	}
	public void ShowKeyAdds(string zoneId)
	{

		if (string.IsNullOrEmpty (zoneId)) {
			zoneId = null;
		}
		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleShowResultKey;
		Advertisement.Show (zoneId, options);

	}

	public void ShowWatchedKeyVideo (string zoneId)
	{
		if (string.IsNullOrEmpty (zoneId)) {
			zoneId = null;
		}
		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleShowResultWatchedKeyVideo;
		Advertisement.Show (zoneId, options);

	}

	void HandleShowResultWatchedKeyVideo(ShowResult result)
	{
		switch (result) {
		case ShowResult.Failed:

			// If internet failed
			SceneManager.LoadScene ("gameover");
			break;
		case ShowResult.Finished:
			GlobalVariables.extralifes++;
			GlobalVariables.keys = PlayerPrefs.GetInt ("keys");
			GlobalVariables.keys--;
			GlobalFunctions.achieviments ("adds");

			PlayerPrefs.SetInt ("keys",GlobalVariables.keys);
//			print ("ads playing uso de chave: " + PlayerPrefs.GetInt ("keys"));
			showWatchedKeyVideo.SetActive (false);
			gameOverTxt.SetActive (false);
			GlobalVariables.dead = false;
			GlobalVariables.actualPlayer.SendMessage ("Restart", SendMessageOptions.DontRequireReceiver);
			break;
		case ShowResult.Skipped:
			SceneManager.LoadScene ("gameover");
			break;
		}
	}
	void HandleShowResultKey(ShowResult result)
	{
		switch (result) {
		case ShowResult.Failed:

			// If internet failed
			SceneManager.LoadScene ("gameover");
			break;
		case ShowResult.Finished:
			if (idAdd == 0) {
				// It is not the first time anymore
				PlayerPrefs.SetInt ("firstplay", 1);
//				print ("ads playing primeira vez: " + PlayerPrefs.GetInt ("keys"));

			}
				
			GlobalVariables.extralifes++;
			GlobalFunctions.achieviments ("adds");

			showKeyAdds.SetActive (false);
			gameOverTxt.SetActive (false);
			GlobalVariables.dead = false;
			GlobalVariables.actualPlayer.SendMessage ("Restart", SendMessageOptions.DontRequireReceiver);
			break;
		case ShowResult.Skipped:
			SceneManager.LoadScene ("gameover");
			break;
		}
	}
}
