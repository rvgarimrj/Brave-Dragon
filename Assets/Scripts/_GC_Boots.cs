using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GC_Boots : MonoBehaviour {
	[SerializeField] private Text 	coins_TXT,points_TXT;
	[SerializeField] private int 	extralifes;

	// Use this for initialization
	void Start () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();
		points_TXT.text = PlayerPrefs.GetInt ("points").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();
		points_TXT.text = PlayerPrefs.GetInt ("points").ToString ();
	}
}
