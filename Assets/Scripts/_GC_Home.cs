using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class _GC_Home : MonoBehaviour,IPointerDownHandler {
	[SerializeField] private Text 	coins_TXT,points_TXT;
	[SerializeField] private int 	extralifes;
	// Use this for initialization
	void Start () {
		GlobalVariables.Playing = false;
		GlobalVariables.showAdds = true;
		CreateKeys ();
		GlobalVariables.extralifes = PlayerPrefs.GetInt ("extralifes");
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();
		points_TXT.text = PlayerPrefs.GetInt ("points").ToString ();
//		print ("Home:  " + GlobalVariables.extralifes);
//		print ("Home: " + GlobalVariables.keys);
	}
	
	// Update is called once per frame
	void Update () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();
		points_TXT.text = PlayerPrefs.GetInt ("points").ToString ();
	}
	public void OnPointerDown(PointerEventData ped)
	{
		Application.Quit ();
	}

	void CreateKeys()
	{
		if (!PlayerPrefs.HasKey ("adds")) {
			PlayerPrefs.SetInt ("adds", 0);
		}

		if (!PlayerPrefs.HasKey ("50enemies")) {
			PlayerPrefs.SetInt ("50enemies", 0);
		}

		if (!PlayerPrefs.HasKey ("100enemies")) {
			PlayerPrefs.SetInt ("100enemies", 0);
		}

		if (!PlayerPrefs.HasKey ("4powerups")) {
			PlayerPrefs.SetInt ("4powerups", 0);
		}

		if (!PlayerPrefs.HasKey ("1000points")) {
			PlayerPrefs.SetInt ("1000points", 0);
		}

		if (!PlayerPrefs.HasKey ("5000points")) {
			PlayerPrefs.SetInt ("5000points", 0);
		}

		if (!PlayerPrefs.HasKey ("extralifes")) {
			PlayerPrefs.SetInt ("extralifes", 2);
		}

		if (!PlayerPrefs.HasKey ("coins")) {
			PlayerPrefs.SetInt ("coins", 0);
		}

		if (!PlayerPrefs.HasKey ("points")) {
			PlayerPrefs.SetInt ("points", 0);
		}

		if (!PlayerPrefs.HasKey ("firstplay")) {
			PlayerPrefs.SetInt ("firstplay", 0);
		}

		if (!PlayerPrefs.HasKey ("invencible")) {
			PlayerPrefs.SetInt ("invencible", 0);
		}

		if (!PlayerPrefs.HasKey ("keys")) {
			PlayerPrefs.SetInt ("keys", 0);
		}

		if (!PlayerPrefs.HasKey ("timeplaying")) {
			PlayerPrefs.SetInt ("timeplaying", 0);
		}

		// if (!PlayerPrefs.HasKey ("redinvencibletime")) {
		// 	PlayerPrefs.SetInt ("redinvencibletime", 5);

		// }
		// if (!PlayerPrefs.HasKey ("greeninvencibletime")) {
		// 	PlayerPrefs.SetInt ("greeninvencibletime", 5);

		// }
		// if (!PlayerPrefs.HasKey ("blueinvencibletime")) {
		// 	PlayerPrefs.SetInt ("blueinvencibletime", 5);

		// }
		// if (!PlayerPrefs.HasKey ("yellowinvencibletime")) {
		// 	PlayerPrefs.SetInt ("yellowinvencibletime", 5);

		//}
		if (!PlayerPrefs.HasKey ("greenenabled")) {
			PlayerPrefs.SetInt ("greenenabled", 0);
		}

		if (!PlayerPrefs.HasKey ("yellowenabled")) {
			PlayerPrefs.SetInt ("yellowenabled", 0);
		}
		if (!PlayerPrefs.HasKey ("blueenabled")) {
			PlayerPrefs.SetInt ("blueenabled", 0);
		}
		if (!PlayerPrefs.HasKey ("redpower")) {
			PlayerPrefs.SetInt ("redpower", 1);
		}
		if (!PlayerPrefs.HasKey ("redspeed")) {
			PlayerPrefs.SetInt ("redspeed", 1);
		}
		if (!PlayerPrefs.HasKey ("redshoot")) {
			PlayerPrefs.SetInt ("redshoot", 1);
		}
		if (!PlayerPrefs.HasKey ("greenpower")) {
			PlayerPrefs.SetInt ("greenpower", 2);
		}
		if (!PlayerPrefs.HasKey ("greenspeed")) {
			PlayerPrefs.SetInt ("greenspeed", 2);
		}
		if (!PlayerPrefs.HasKey ("greenshoot")) {
			PlayerPrefs.SetInt ("greenshoot", 2);
		}

		if (!PlayerPrefs.HasKey ("yellowpower")) {
			PlayerPrefs.SetInt ("yellowpower", 2);
		}
		if (!PlayerPrefs.HasKey ("yellowspeed")) {
			PlayerPrefs.SetInt ("yellowspeed", 2);
		}
		if (!PlayerPrefs.HasKey ("yellowshoot")) {
			PlayerPrefs.SetInt ("yellowshoot", 3);
		}

		if (!PlayerPrefs.HasKey ("bluepower")) {
			PlayerPrefs.SetInt ("bluepower", 2);
		}
		if (!PlayerPrefs.HasKey ("bluespeed")) {
			PlayerPrefs.SetInt ("bluespeed", 2);
		}
		if (!PlayerPrefs.HasKey ("blueshoot")) {
			PlayerPrefs.SetInt ("blueshoot", 4);
		}
		if (!PlayerPrefs.HasKey ("redinvincible")) {
			PlayerPrefs.SetInt ("redinvincible", 1);
		}
		if (!PlayerPrefs.HasKey ("greeninvincible")) {
			PlayerPrefs.SetInt ("greeninvincible", 1);
		}
		if (!PlayerPrefs.HasKey ("yellowinvincible")) {
			PlayerPrefs.SetInt ("yellowinvincible", 1);
		}
		if (!PlayerPrefs.HasKey ("greeninvincible")) {
			PlayerPrefs.SetInt ("greeninvincible", 1);
		}
	}
}
