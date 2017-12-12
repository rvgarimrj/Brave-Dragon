using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GC_Panel_Home : MonoBehaviour {
	[SerializeField] private Image 	redpower1,redpower2,redpower3,redpower4,
									redspeed1,redspeed2,redspeed3,redspeed4,
									redfire1,redfire2,redfire3,redfire4,
									redinvincible1,redinvincible2,redinvincible3,redinvincible4,
									greenpower1,greenpower2,greenpower3,greenpower4,
									greenspeed1,greenspeed2,greenspeed3,greenspeed4,
									greenfire1,greenfire2,greenfire3,greenfire4,
									greeninvincible1,greeninvincible2,greeninvincible3,greeninvincible4,
									bluepower1,bluepower2,bluepower3,bluepower4,
									bluespeed1,bluespeed2,bluespeed3,bluespeed4,
									bluefire1,bluefire2,bluefire3,bluefire4,
									blueinvincible1,blueinvincible2,blueinvincible3,blueinvincible4,
									yellowpower1,yellowpower2,yellowpower3,yellowpower4,
									yellowspeed1,yellowspeed2,yellowspeed3,yellowspeed4,
									yellowfire1,yellowfire2,yellowfire3,yellowfire4,
									yellowinvincible1,yellowinvincible2,yellowinvincible3,yellowinvincible4;

	[SerializeField] private Sprite[] on_off;
	

	// Use this for initialization
	void Start () {

		SetPanel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetPanel()
	{
		// Red Dragon Panel Check
		switch (PlayerPrefs.GetInt ("redpower")) {
		case 1:
			redpower1.sprite = on_off [0];
			redpower2.sprite = on_off [1];
			redpower3.sprite = on_off [1];
			redpower4.sprite = on_off [1];
			break;
		case 2:
			redpower1.sprite = on_off [0];
			redpower2.sprite = on_off [0];
			redpower3.sprite = on_off [1];
			redpower4.sprite = on_off [1];
			break;
		case 3:
			redpower1.sprite = on_off [0];
			redpower2.sprite = on_off [0];
			redpower3.sprite = on_off [0];
			redpower4.sprite = on_off [1];
			break;
		case 4:
			redpower1.sprite = on_off [0];
			redpower2.sprite = on_off [0];
			redpower3.sprite = on_off [0];
			redpower4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("redspeed")) {
		case 1:
			redspeed1.sprite = on_off [0];
			redspeed2.sprite = on_off [1];
			redspeed3.sprite = on_off [1];
			redspeed4.sprite = on_off [1];
			break;
		case 2:
			redspeed1.sprite = on_off [0];
			redspeed2.sprite = on_off [0];
			redspeed3.sprite = on_off [1];
			redspeed4.sprite = on_off [1];
			break;
		case 3:
			redspeed1.sprite = on_off [0];
			redspeed2.sprite = on_off [0];
			redspeed3.sprite = on_off [0];
			redspeed4.sprite = on_off [1];
			break;
		case 4:
			redspeed1.sprite = on_off [0];
			redspeed2.sprite = on_off [0];
			redspeed3.sprite = on_off [0];
			redspeed4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("redshoot")) {
		case 1:
			redfire1.sprite = on_off [0];
			redfire2.sprite = on_off [1];
			redfire3.sprite = on_off [1];
			redfire4.sprite = on_off [1];
			break;
		case 2:
			redfire1.sprite = on_off [0];
			redfire2.sprite = on_off [0];
			redfire3.sprite = on_off [1];
			redfire4.sprite = on_off [1];
			break;
		case 3:
			redfire1.sprite = on_off [0];
			redfire2.sprite = on_off [0];
			redfire3.sprite = on_off [0];
			redfire4.sprite = on_off [1];
			break;
		case 4:
			redfire1.sprite = on_off [0];
			redfire2.sprite = on_off [0];
			redfire3.sprite = on_off [0];
			redfire4.sprite = on_off [0];
			break;
		}
		switch (PlayerPrefs.GetInt ("redinvincible")) {
		case 1:
			redinvincible1.sprite = on_off [0];
			redinvincible2.sprite = on_off [1];
			redinvincible3.sprite = on_off [1];
			redinvincible4.sprite = on_off [1];
			break;
		case 2:
			redinvincible1.sprite = on_off [0];
			redinvincible2.sprite = on_off [0];
			redinvincible3.sprite = on_off [1];
			redinvincible4.sprite = on_off [1];
			break;
		case 3:
			redinvincible1.sprite = on_off [0];
			redinvincible2.sprite = on_off [0];
			redinvincible3.sprite = on_off [0];
			redinvincible4.sprite = on_off [1];
			break;
		case 4:
			redinvincible1.sprite = on_off [0];
			redinvincible2.sprite = on_off [0];
			redinvincible3.sprite = on_off [0];
			redinvincible4.sprite = on_off [0];
			break;
		}

			// Green Dragon Panel Check
		switch (PlayerPrefs.GetInt ("greenpower")) {
		case 1:
			greenpower1.sprite = on_off [0];
			greenpower2.sprite = on_off [1];
			greenpower3.sprite = on_off [1];
			greenpower4.sprite = on_off [1];
			break;
		case 2:
			greenpower1.sprite = on_off [0];
			greenpower2.sprite = on_off [0];
			greenpower3.sprite = on_off [1];
			greenpower4.sprite = on_off [1];
			break;
		case 3:
			greenpower1.sprite = on_off [0];
			greenpower2.sprite = on_off [0];
			greenpower3.sprite = on_off [0];
			greenpower4.sprite = on_off [1];
			break;
		case 4:
			greenpower1.sprite = on_off [0];
			greenpower2.sprite = on_off [0];
			greenpower3.sprite = on_off [0];
			greenpower4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("greenspeed")) {
		case 1:
			greenspeed1.sprite = on_off [0];
			greenspeed2.sprite = on_off [1];
			greenspeed3.sprite = on_off [1];
			greenspeed4.sprite = on_off [1];
			break;
		case 2:
			greenspeed1.sprite = on_off [0];
			greenspeed2.sprite = on_off [0];
			greenspeed3.sprite = on_off [1];
			greenspeed4.sprite = on_off [1];
			break;
		case 3:
			greenspeed1.sprite = on_off [0];
			greenspeed2.sprite = on_off [0];
			greenspeed3.sprite = on_off [0];
			greenspeed4.sprite = on_off [1];
			break;
		case 4:
			greenspeed1.sprite = on_off [0];
			greenspeed2.sprite = on_off [0];
			greenspeed3.sprite = on_off [0];
			greenspeed4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("greenshoot")) {
		case 1:
			greenfire1.sprite = on_off [0];
			greenfire2.sprite = on_off [1];
			greenfire3.sprite = on_off [1];
			greenfire4.sprite = on_off [1];
			break;
		case 2:
			greenfire1.sprite = on_off [0];
			greenfire2.sprite = on_off [0];
			greenfire3.sprite = on_off [1];
			greenfire4.sprite = on_off [1];
			break;
		case 3:
			greenfire1.sprite = on_off [0];
			greenfire2.sprite = on_off [0];
			greenfire3.sprite = on_off [0];
			greenfire4.sprite = on_off [1];
			break;
		case 4:
			greenfire1.sprite = on_off [0];
			greenfire2.sprite = on_off [0];
			greenfire3.sprite = on_off [0];
			greenfire4.sprite = on_off [0];
			break;
		}
		switch (PlayerPrefs.GetInt ("greeninvincible")) {
		case 1:
			greeninvincible1.sprite = on_off [0];
			greeninvincible2.sprite = on_off [1];
			greeninvincible3.sprite = on_off [1];
			greeninvincible4.sprite = on_off [1];
			break;
		case 2:
			greeninvincible1.sprite = on_off [0];
			greeninvincible2.sprite = on_off [0];
			greeninvincible3.sprite = on_off [1];
			greeninvincible4.sprite = on_off [1];
			break;
		case 3:
			greeninvincible1.sprite = on_off [0];
			greeninvincible2.sprite = on_off [0];
			greeninvincible3.sprite = on_off [0];
			greeninvincible4.sprite = on_off [1];
			break;
		case 4:
			greeninvincible1.sprite = on_off [0];
			greeninvincible2.sprite = on_off [0];
			greeninvincible3.sprite = on_off [0];
			greeninvincible4.sprite = on_off [0];
			break;
		}
			// Yellow Dragon Panel Check
		switch (PlayerPrefs.GetInt ("yellowpower")) {
		case 1:
			yellowpower1.sprite = on_off [0];
			yellowpower2.sprite = on_off [1];
			yellowpower3.sprite = on_off [1];
			yellowpower4.sprite = on_off [1];
			break;
		case 2:
			yellowpower1.sprite = on_off [0];
			yellowpower2.sprite = on_off [0];
			yellowpower3.sprite = on_off [1];
			yellowpower4.sprite = on_off [1];
			break;
		case 3:
			yellowpower1.sprite = on_off [0];
			yellowpower2.sprite = on_off [0];
			yellowpower3.sprite = on_off [0];
			yellowpower4.sprite = on_off [1];
			break;
		case 4:
			yellowpower1.sprite = on_off [0];
			yellowpower2.sprite = on_off [0];
			yellowpower3.sprite = on_off [0];
			yellowpower4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("yellowspeed")) {
		case 1:
			yellowspeed1.sprite = on_off [0];
			yellowspeed2.sprite = on_off [1];
			yellowspeed3.sprite = on_off [1];
			yellowspeed4.sprite = on_off [1];
			break;
		case 2:
			yellowspeed1.sprite = on_off [0];
			yellowspeed2.sprite = on_off [0];
			yellowspeed3.sprite = on_off [1];
			yellowspeed4.sprite = on_off [1];
			break;
		case 3:
			yellowspeed1.sprite = on_off [0];
			yellowspeed2.sprite = on_off [0];
			yellowspeed3.sprite = on_off [0];
			yellowspeed4.sprite = on_off [1];
			break;
		case 4:
			yellowspeed1.sprite = on_off [0];
			yellowspeed2.sprite = on_off [0];
			yellowspeed3.sprite = on_off [0];
			yellowspeed4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("yellowshoot")) {
		case 1:
			yellowfire1.sprite = on_off [0];
			yellowfire2.sprite = on_off [1];
			yellowfire3.sprite = on_off [1];
			yellowfire4.sprite = on_off [1];
			break;
		case 2:
			yellowfire1.sprite = on_off [0];
			yellowfire2.sprite = on_off [0];
			yellowfire3.sprite = on_off [1];
			yellowfire4.sprite = on_off [1];
			break;
		case 3:
			yellowfire1.sprite = on_off [0];
			yellowfire2.sprite = on_off [0];
			yellowfire3.sprite = on_off [0];
			yellowfire4.sprite = on_off [1];
			break;
		case 4:
			yellowfire1.sprite = on_off [0];
			yellowfire2.sprite = on_off [0];
			yellowfire3.sprite = on_off [0];
			yellowfire4.sprite = on_off [0];
			break;
		}
		switch (PlayerPrefs.GetInt ("yellowinvincible")) {
		case 1:
			yellowinvincible1.sprite = on_off [0];
			yellowinvincible2.sprite = on_off [1];
			yellowinvincible3.sprite = on_off [1];
			yellowinvincible4.sprite = on_off [1];
			break;
		case 2:
			yellowinvincible1.sprite = on_off [0];
			yellowinvincible2.sprite = on_off [0];
			yellowinvincible3.sprite = on_off [1];
			yellowinvincible4.sprite = on_off [1];
			break;
		case 3:
			yellowinvincible1.sprite = on_off [0];
			yellowinvincible2.sprite = on_off [0];
			yellowinvincible3.sprite = on_off [0];
			yellowinvincible4.sprite = on_off [1];
			break;
		case 4:
			yellowinvincible1.sprite = on_off [0];
			yellowinvincible2.sprite = on_off [0];
			yellowinvincible3.sprite = on_off [0];
			yellowinvincible4.sprite = on_off [0];
			break;
		}
			// Blue Dragon Panel Check
		switch (PlayerPrefs.GetInt ("bluepower")) {
		case 1:
			bluepower1.sprite = on_off [0];
			bluepower2.sprite = on_off [1];
			bluepower3.sprite = on_off [1];
			bluepower4.sprite = on_off [1];
			break;
		case 2:
			bluepower1.sprite = on_off [0];
			bluepower2.sprite = on_off [0];
			bluepower3.sprite = on_off [1];
			bluepower4.sprite = on_off [1];
			break;
		case 3:
			bluepower1.sprite = on_off [0];
			bluepower2.sprite = on_off [0];
			bluepower3.sprite = on_off [0];
			bluepower4.sprite = on_off [1];
			break;
		case 4:
			bluepower1.sprite = on_off [0];
			bluepower2.sprite = on_off [0];
			bluepower3.sprite = on_off [0];
			bluepower4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("bluespeed")) {
		case 1:
			bluespeed1.sprite = on_off [0];
			bluespeed2.sprite = on_off [1];
			bluespeed3.sprite = on_off [1];
			bluespeed4.sprite = on_off [1];
			break;
		case 2:
			bluespeed1.sprite = on_off [0];
			bluespeed2.sprite = on_off [0];
			bluespeed3.sprite = on_off [1];
			bluespeed4.sprite = on_off [1];
			break;
		case 3:
			bluespeed1.sprite = on_off [0];
			bluespeed2.sprite = on_off [0];
			bluespeed3.sprite = on_off [0];
			bluespeed4.sprite = on_off [1];
			break;
		case 4:
			bluespeed1.sprite = on_off [0];
			bluespeed2.sprite = on_off [0];
			bluespeed3.sprite = on_off [0];
			bluespeed4.sprite = on_off [0];
			break;
		}

		switch (PlayerPrefs.GetInt ("blueshoot")) {
		case 1:
			bluefire1.sprite = on_off [0];
			bluefire2.sprite = on_off [1];
			bluefire3.sprite = on_off [1];
			bluefire4.sprite = on_off [1];
			break;
		case 2:
			bluefire1.sprite = on_off [0];
			bluefire2.sprite = on_off [0];
			bluefire3.sprite = on_off [1];
			bluefire4.sprite = on_off [1];
			break;
		case 3:
			bluefire1.sprite = on_off [0];
			bluefire2.sprite = on_off [0];
			bluefire3.sprite = on_off [0];
			bluefire4.sprite = on_off [1];
			break;
		case 4:
			bluefire1.sprite = on_off [0];
			bluefire2.sprite = on_off [0];
			bluefire3.sprite = on_off [0];
			bluefire4.sprite = on_off [0];
			break;
		}
		switch (PlayerPrefs.GetInt ("blueinvincible")) {
		case 1:
			blueinvincible1.sprite = on_off [0];
			blueinvincible2.sprite = on_off [1];
			blueinvincible3.sprite = on_off [1];
			blueinvincible4.sprite = on_off [1];
			break;
		case 2:
			blueinvincible1.sprite = on_off [0];
			blueinvincible2.sprite = on_off [0];
			blueinvincible3.sprite = on_off [1];
			blueinvincible4.sprite = on_off [1];
			break;
		case 3:
			blueinvincible1.sprite = on_off [0];
			blueinvincible2.sprite = on_off [0];
			blueinvincible3.sprite = on_off [0];
			blueinvincible4.sprite = on_off [1];
			break;
		case 4:
			blueinvincible1.sprite = on_off [0];
			blueinvincible2.sprite = on_off [0];
			blueinvincible3.sprite = on_off [0];
			blueinvincible4.sprite = on_off [0];
			break;
		}
	}
}
