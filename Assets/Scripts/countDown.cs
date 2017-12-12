using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class countDown : MonoBehaviour {
	[SerializeField] private Sprite[] 	countdown;
	[SerializeField] private Image 		imageCountDown;
	[SerializeField] private GameObject	panelCountDown;
	[SerializeField] private GameObject pausePanel;
	private int i;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Continue()
	{

		yield return new WaitForSeconds (1);
		i++;
		if (i <= 4) {
			imageCountDown.sprite = countdown [i];	
			StartCoroutine ("Continue");

		} else {
			Time.timeScale = 1;
			panelCountDown.SetActive (false);
		}

	}

	public void ContinueGame()
	{
		pausePanel.SetActive (false);

		panelCountDown.SetActive (true);
		StartCoroutine ("Continue");
	}
}
