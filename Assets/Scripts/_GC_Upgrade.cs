using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GC_Upgrade : MonoBehaviour {
	[SerializeField] private GameObject redpower1,redpower2,redpower3,redpower4,
										redspeed1,redspeed2,redspeed3,redspeed4,
										redshoot1,redshoot2,redshoot3,redshoot4,
										redinvincible1,redinvincible2,redinvincible3,redinvincible4,
										greenpower1,greenpower2,greenpower3,greenpower4,
										greenspeed1,greenspeed2,greenspeed3,greenspeed4,
										greenshoot1,greenshoot2,greenshoot3,greenshoot4,
										greeninvincible1,greeninvincible2,greeninvincible3,greeninvincible4,
										bluepower1,bluepower2,bluepower3,bluepower4,
										bluespeed1,bluespeed2,bluespeed3,bluespeed4,
										blueshoot1,blueshoot2,blueshoot3,blueshoot4,
										blueinvincible1,blueinvincible2,blueinvincible3,blueinvincible4,
										yellowpower1,yellowpower2,yellowpower3,yellowpower4,
										yellowspeed1,yellowspeed2,yellowspeed3,yellowspeed4,
										yellowshoot1,yellowshoot2,yellowshoot3,yellowshoot4,
										yellowinvincible1,yellowinvincible2,yellowinvincible3,yellowinvincible4,
										redpowerFull,redspeedFull,redshootFull,redinvincibleFull,
										greenpowerFull,greenspeedFull,greenshootFull,greeninvincibleFull,
										yellowpowerFull,yellowspeedFull,yellowshootFull,yellowinvincibleFull,
										bluepowerFull,bluespeedFull,blueshootFull,blueinvincibleFull,Coins_Needed;

	[SerializeField] private GameObject red, green, yellow, blue,redLeft, redRight, greenLeft,
										greenRight, yellowLeft, yellowRight, blueLeft, blueRight,
										redPanel, greenPanel, yellowPanel, bluePanel,
										greenUpgrade, yellowUpgrade, blueUpgrade,
										greenPurchased, yellowPurchased, bluePurchased;
	[SerializeField] private Text coins_TXT,coins_TXT_needed;
	[SerializeField] private Button     redpower2Btn,redpower3Btn,redpower4Btn,redspeed2Btn,redspeed3Btn,redspeed4Btn,
										redshoot2Btn,redshoot3Btn,redshoot4Btn,redinvincible2Btn,redinvincible3Btn,redinvincible4Btn,
										greenpower2Btn,greenpower3Btn,greenpower4Btn,greenspeed2Btn,greenspeed3Btn,greenspeed4Btn,
										greenshoot2Btn,greenshoot3Btn,greenshoot4Btn,greeninvincible2Btn,greeninvincible3Btn,greeninvincible4Btn,
										yellowpower2Btn,yellowpower3Btn,yellowpower4Btn,yellowspeed2Btn,yellowspeed3Btn,yellowspeed4Btn,
										yellowshoot2Btn,yellowshoot3Btn,yellowshoot4Btn,yellowinvincible2Btn,yellowinvincible3Btn,yellowinvincible4Btn,
										bluepower2Btn,bluepower3Btn,bluepower4Btn,bluespeed2Btn,bluespeed3Btn,bluespeed4Btn,
										blueshoot2Btn,blueshoot3Btn,blueshoot4Btn,blueinvincible2Btn,blueinvincible3Btn,blueinvincible4Btn,
										greenUpgradeBtn,yellowUpgradeBtn,blueUpgradeBtn;
	[SerializeField] private int        redpower2Coins,redpower3Coins,redpower4Coins,redspeed2Coins,redspeed3Coins,redspeed4Coins,
										redshoot2Coins,redshoot3Coins,redshoot4Coins,redinvincible2Coins,redinvincible3Coins,redinvincible4Coins,
										greenpower2Coins,greenpower3Coins,greenpower4Coins,greenspeed2Coins,greenspeed3Coins,greenspeed4Coins,
										greenshoot2Coins,greenshoot3Coins,greenshoot4Coins,greeninvincible2Coins,greeninvincible3Coins,greeninvincible4Coins,
										yellowpower2Coins,yellowpower3Coins,yellowpower4Coins,yellowspeed2Coins,yellowspeed3Coins,yellowspeed4Coins,
										yellowshoot2Coins,yellowshoot3Coins,yellowshoot4Coins,yellowinvincible2Coins,yellowinvincible3Coins,yellowinvincible4Coins,
										bluepower2Coins,bluepower3Coins,bluepower4Coins,bluespeed2Coins,bluespeed3Coins,bluespeed4Coins,
										blueshoot2Coins,blueshoot3Coins,blueshoot4Coins,blueinvincible2Coins,blueinvincible3Coins,blueinvincible4Coins,
										greenPlayerCoins,yellowPlayerCoins,bluePlayerCoins;
	private string hability;
	private int coins,number;

	// Use this for initialization
	void Start () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();

		SetPanel();
		if (PlayerPrefs.GetInt ("greenenabled") == 1) {
			greenPurchased.SetActive (true);
			greenUpgrade.SetActive (false);
		} else {
			greenPurchased.SetActive (false);
			greenUpgrade.SetActive (true);
		}
			

		if (PlayerPrefs.GetInt ("yellowenabled") == 1) {
			yellowPurchased.SetActive (true);
			yellowUpgrade.SetActive (false);
		} else {
			yellowPurchased.SetActive (false);
			yellowUpgrade.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("blueenabled") == 1) {
			bluePurchased.SetActive (true);
			blueUpgrade.SetActive (false);
		} else {
			bluePurchased.SetActive (false);
			blueUpgrade.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString ();
		SetPanel ();
	}
		


	// **************************************************************************
	// Buttons CallBacks

	void OnEnable()
	{
		//Register Button Events
		greenUpgradeBtn.onClick.AddListener(() => Buy_Item("greenplayer",1,greenPlayerCoins));
		yellowUpgradeBtn.onClick.AddListener(() => Buy_Item("yellowplayer",1,yellowPlayerCoins));
		blueUpgradeBtn.onClick.AddListener(() => Buy_Item("blueplayer",1,bluePlayerCoins));

		redpower2Btn.onClick.AddListener(() => Buy_Item("redpower",2,redpower2Coins));
		redpower3Btn.onClick.AddListener(() => Buy_Item("redpower",3,redpower3Coins));
		redpower4Btn.onClick.AddListener(() => Buy_Item("redpower",4,redpower4Coins));
		redspeed2Btn.onClick.AddListener(() => Buy_Item("redspeed",2,redspeed2Coins));
		redspeed3Btn.onClick.AddListener(() => Buy_Item("redspeed",3,redspeed3Coins));
		redspeed4Btn.onClick.AddListener(() => Buy_Item("redspeed",4,redspeed4Coins));
		redshoot2Btn.onClick.AddListener(() => Buy_Item("redshoot",2,redshoot2Coins));
		redshoot3Btn.onClick.AddListener(() => Buy_Item("redshoot",3,redshoot3Coins));
		redshoot4Btn.onClick.AddListener(() => Buy_Item("redshoot",4,redshoot4Coins));
		redinvincible2Btn.onClick.AddListener(() => Buy_Item("redinvincible",2,redinvincible2Coins));
		redinvincible3Btn.onClick.AddListener(() => Buy_Item("redinvincible",3,redinvincible3Coins));
		redinvincible4Btn.onClick.AddListener(() => Buy_Item("redinvincible",4,redinvincible4Coins));

		greenpower2Btn.onClick.AddListener(() => Buy_Item("greenpower",2,greenpower2Coins));
		greenpower3Btn.onClick.AddListener(() => Buy_Item("greenpower",3,greenpower3Coins));
		greenpower4Btn.onClick.AddListener(() => Buy_Item("greenpower",4,greenpower4Coins));
		greenspeed2Btn.onClick.AddListener(() => Buy_Item("greenspeed",2,greenspeed2Coins));
		greenspeed3Btn.onClick.AddListener(() => Buy_Item("greenspeed",3,greenspeed3Coins));
		greenspeed4Btn.onClick.AddListener(() => Buy_Item("greenspeed",4,greenspeed4Coins));
		greenshoot2Btn.onClick.AddListener(() => Buy_Item("greenshoot",2,greenshoot2Coins));
		greenshoot3Btn.onClick.AddListener(() => Buy_Item("greenshoot",3,greenshoot3Coins));
		greenshoot4Btn.onClick.AddListener(() => Buy_Item("greenshoot",4,greenshoot4Coins));
		greeninvincible2Btn.onClick.AddListener(() => Buy_Item("greeninvincible",2,greeninvincible2Coins));
		greeninvincible3Btn.onClick.AddListener(() => Buy_Item("greeninvincible",3,greeninvincible3Coins));
		greeninvincible4Btn.onClick.AddListener(() => Buy_Item("greeninvincible",4,greeninvincible4Coins));

		yellowpower2Btn.onClick.AddListener(() => Buy_Item("yellowpower",2,yellowpower2Coins));
		yellowpower3Btn.onClick.AddListener(() => Buy_Item("yellowpower",3,yellowpower3Coins));
		yellowpower4Btn.onClick.AddListener(() => Buy_Item("yellowpower",4,yellowpower4Coins));
		yellowspeed2Btn.onClick.AddListener(() => Buy_Item("yellowspeed",2,yellowspeed2Coins));
		yellowspeed3Btn.onClick.AddListener(() => Buy_Item("yellowspeed",3,yellowspeed3Coins));
		yellowspeed4Btn.onClick.AddListener(() => Buy_Item("yellowspeed",4,yellowspeed4Coins));
		yellowshoot2Btn.onClick.AddListener(() => Buy_Item("yellowshoot",2,yellowshoot2Coins));
		yellowshoot3Btn.onClick.AddListener(() => Buy_Item("yellowshoot",3,yellowshoot3Coins));
		yellowshoot4Btn.onClick.AddListener(() => Buy_Item("yellowshoot",4,yellowshoot4Coins));
		yellowinvincible2Btn.onClick.AddListener(() => Buy_Item("yellowinvincible",2,yellowinvincible2Coins));
		yellowinvincible3Btn.onClick.AddListener(() => Buy_Item("yellowinvincible",3,yellowinvincible3Coins));
		yellowinvincible4Btn.onClick.AddListener(() => Buy_Item("yellowinvincible",4,yellowinvincible4Coins));

		bluepower2Btn.onClick.AddListener(() => Buy_Item("bluepower",2,bluepower2Coins));
		bluepower3Btn.onClick.AddListener(() => Buy_Item("bluepower",3,bluepower3Coins));
		bluepower4Btn.onClick.AddListener(() => Buy_Item("bluepower",4,bluepower4Coins));
		bluespeed2Btn.onClick.AddListener(() => Buy_Item("bluespeed",2,bluespeed2Coins));
		bluespeed3Btn.onClick.AddListener(() => Buy_Item("bluespeed",3,bluespeed3Coins));
		bluespeed4Btn.onClick.AddListener(() => Buy_Item("bluespeed",4,bluespeed4Coins));
		blueshoot2Btn.onClick.AddListener(() => Buy_Item("blueshoot",2,blueshoot2Coins));
		blueshoot3Btn.onClick.AddListener(() => Buy_Item("blueshoot",3,blueshoot3Coins));
		blueshoot4Btn.onClick.AddListener(() => Buy_Item("blueshoot",4,blueshoot4Coins));
		blueinvincible2Btn.onClick.AddListener(() => Buy_Item("blueinvincible",2,blueinvincible2Coins));
		blueinvincible3Btn.onClick.AddListener(() => Buy_Item("blueinvincible",3,blueinvincible3Coins));
		blueinvincible4Btn.onClick.AddListener(() => Buy_Item("blueinvincible",4,blueinvincible4Coins));
	}

	void OnDisable()
	{
		//Un-Register Button Events
		redpower2Btn.onClick.RemoveAllListeners();
	}

	private void Buy_Item(string item, int n, int coins_needed) // Será meu callback 
	{
		if (PlayerPrefs.GetInt ("coins") - coins_needed >= 0) {
			switch (item) {
			case "greenplayer":
				PlayerPrefs.SetInt ("greenenabled", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				GlobalFunctions.achieviments ("greenplayerunlock");
				break;
			case "yellowplayer":
				PlayerPrefs.SetInt ("yellowenabled", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				GlobalFunctions.achieviments ("yellowplayerunlock");

				break;
			case "blueplayer":
				PlayerPrefs.SetInt ("blueenabled", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				GlobalFunctions.achieviments ("blueplayerunlock");

				break;
			case "redpower":
				PlayerPrefs.SetInt ("redpower", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "redspeed":
				PlayerPrefs.SetInt ("redspeed", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "redshoot":
				PlayerPrefs.SetInt ("redshoot", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "redinvincible":
				PlayerPrefs.SetInt ("redinvincible", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "greenspeed":
				PlayerPrefs.SetInt ("greenspeed", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "greenshoot":
				PlayerPrefs.SetInt ("greenshoot", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "greeninvincible":
				PlayerPrefs.SetInt ("greeninvincible", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "yellowspeed":
				PlayerPrefs.SetInt ("yellowspeed", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "yellowshoot":
				PlayerPrefs.SetInt ("yellowshoot", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "yellowinvincible":
				PlayerPrefs.SetInt ("yellowinvincible", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "bluespeed":
				PlayerPrefs.SetInt ("bluespeed", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "blueshoot":
				PlayerPrefs.SetInt ("blueshoot", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "blueinvincible":
				PlayerPrefs.SetInt ("blueinvincible", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "greenpower":
				PlayerPrefs.SetInt ("greenpower", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "yellowpower":
				PlayerPrefs.SetInt ("yellowpower", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			case "bluepower":
				PlayerPrefs.SetInt ("bluepower", n);
				coins = PlayerPrefs.GetInt ("coins") - coins_needed;
				PlayerPrefs.SetInt ("coins", coins);
				break;
			}
		} else {
			Coins_Needed.SetActive (true);
			coins_TXT_needed.text = ("You need more " + (coins_needed - PlayerPrefs.GetInt ("coins")) + " coins.");
//			print ("not enought coins. You need more " + (coins_needed - PlayerPrefs.GetInt ("coins")) + " coins.");
		}
	}

	//****************************************************************************
	public void HidePanel()
	{
		Coins_Needed.SetActive (false);
	}
	void SetPanel()
	{
			if (PlayerPrefs.GetInt ("greenenabled") == 0) {
				greenUpgrade.SetActive (true);
				greenPurchased.SetActive (false);
			} else if (PlayerPrefs.GetInt ("greenenabled") == 1) {
				greenUpgrade.SetActive (false);
				greenPurchased.SetActive (true);
			}
			
			if (PlayerPrefs.GetInt ("yellowenabled") == 0) {
				yellowUpgrade.SetActive (true);
				yellowPurchased.SetActive (false);
			} else if (PlayerPrefs.GetInt ("yellowenabled") == 1) {
				yellowUpgrade.SetActive (false);
				yellowPurchased.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("blueenabled") == 0) {
				blueUpgrade.SetActive (true);
				bluePurchased.SetActive (false);
			} else if (PlayerPrefs.GetInt ("blueenabled") == 1) {
				blueUpgrade.SetActive (false);
				bluePurchased.SetActive (true);
			}

			// Red Dragon Panel Check
			switch (PlayerPrefs.GetInt ("redpower")) {
			case 1:
				redpower1.SetActive (false);
				redpower2.SetActive (true);
				redpower3.SetActive (false);
				redpower4.SetActive (false);
				break;
			case 2:
				redpower1.SetActive (false);
				redpower2.SetActive (false);
				redpower3.SetActive (true);
				redpower4.SetActive (false);
				break;
			case 3:
				redpower1.SetActive (false);
				redpower2.SetActive (false);
				redpower3.SetActive (false);
				redpower4.SetActive (true);
				break;
			case 4:
				redpower1.SetActive (false);
				redpower2.SetActive (false);
				redpower3.SetActive (false);
				redpower4.SetActive (false);
				redpowerFull.SetActive (true);
			break;

			}

			switch (PlayerPrefs.GetInt ("redspeed")) {
			case 1:
				redspeed1.SetActive (false);
				redspeed2.SetActive (true);
				redspeed3.SetActive (false);
				redspeed4.SetActive (false);
				break;
			case 2:
				redspeed1.SetActive (false);
				redspeed2.SetActive (false);
				redspeed3.SetActive (true);
				redspeed4.SetActive (false);
				break;
			case 3:
				redspeed1.SetActive (false);
				redspeed2.SetActive (false);
				redspeed3.SetActive (false);
				redspeed4.SetActive (true);			
				break;
			case 4:
				redspeed1.SetActive (false);
				redspeed2.SetActive (false);
				redspeed3.SetActive (false);
				redspeed4.SetActive (false);	
				redspeedFull.SetActive (true);
			break;
			}

			switch (PlayerPrefs.GetInt ("redshoot")) {
			case 1:
				redshoot1.SetActive (false);
				redshoot2.SetActive (true);
				redshoot3.SetActive (false);
				redshoot4.SetActive (false);
				break;
			case 2:
				redshoot1.SetActive (false);
				redshoot2.SetActive (false);
				redshoot3.SetActive (true);
				redshoot4.SetActive (false);
				;
				break;
			case 3:
				redshoot1.SetActive (false);
				redshoot2.SetActive (false);
				redshoot3.SetActive (false);
				redshoot4.SetActive (true);
				break;
			case 4:
				redshoot1.SetActive (false);
				redshoot2.SetActive (false);
				redshoot3.SetActive (false);
				redshoot4.SetActive (false);
				redshootFull.SetActive(true);
				break;
			}
			switch (PlayerPrefs.GetInt ("redinvincible")) {
			case 1:
				redinvincible1.SetActive (false);
				redinvincible2.SetActive (true);
				redinvincible3.SetActive (false);
				redinvincible4.SetActive (false);
				break;
			case 2:
				redinvincible1.SetActive (false);
				redinvincible2.SetActive (false);
				redinvincible3.SetActive (true);
				redinvincible4.SetActive (false);
				break;
			case 3:
				redinvincible1.SetActive (false);
				redinvincible2.SetActive (false);
				redinvincible3.SetActive (false);
				redinvincible4.SetActive (true);
				break;
			case 4:
				redinvincible1.SetActive (false);
				redinvincible2.SetActive (false);
				redinvincible3.SetActive (false);
				redinvincible4.SetActive (false);
				redinvincibleFull.SetActive (true);
				break;
			}
			// Green Dragon Panel Check
			switch (PlayerPrefs.GetInt ("greenpower")) {

		case 1:
			greenpower1.SetActive (false);
			greenpower2.SetActive (true);
			if (PlayerPrefs.GetInt ("greenenabled") == 0) {
					
				greenpower2.GetComponent<Button> ().interactable = false;
			} else {
				greenpower2.GetComponent<Button> ().interactable = true;
			}
				greenpower3.SetActive (false);
				greenpower4.SetActive (false);
				break;
		case 2:
			greenpower1.SetActive (false);
			greenpower2.SetActive (false);
			greenpower3.SetActive (true);
			if (PlayerPrefs.GetInt ("greenenabled") == 0) {

				greenpower3.GetComponent<Button> ().interactable = false;
			} else {
				greenpower3.GetComponent<Button> ().interactable = true;

			}
				greenpower4.SetActive (false);
				break;
			case 3:
				greenpower1.SetActive (false);
				greenpower2.SetActive (false);
				greenpower3.SetActive (false);
				greenpower4.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenpower4.GetComponent<Button> ().interactable = false;
				}
			else {
				greenpower4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				greenpower1.SetActive (false);
				greenpower2.SetActive (false);
				greenpower3.SetActive (false);
				greenpower4.SetActive (false);
				greenpowerFull.SetActive (true);
				break;
			}

			switch (PlayerPrefs.GetInt ("greenspeed")) {
			case 1:
				greenspeed1.SetActive (false);
				greenspeed2.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenspeed2.GetComponent<Button> ().interactable = false;
				}
			else {
				greenspeed2.GetComponent<Button> ().interactable = true;

			}
				greenspeed3.SetActive (false);
				greenspeed4.SetActive (false);
				break;
			case 2:
				greenspeed1.SetActive (false);
				greenspeed2.SetActive (false);
				greenspeed3.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenspeed3.GetComponent<Button> ().interactable = false;
				}
			else {
				greenspeed3.GetComponent<Button> ().interactable = true;

			}

				greenspeed4.SetActive (false);
				break;
			case 3:
				greenspeed1.SetActive (false);
				greenspeed2.SetActive (false);
				greenspeed3.SetActive (false);
				greenspeed4.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenspeed4.GetComponent<Button> ().interactable = false;
				}
			else {
				greenspeed4.GetComponent<Button> ().interactable = true;

			}

				break;
			case 4:
				greenspeed1.SetActive (false);
				greenspeed2.SetActive (false);
				greenspeed3.SetActive (false);
				greenspeed4.SetActive (false);
				greenspeedFull.SetActive (true);
				break;
			}

			switch (PlayerPrefs.GetInt ("greenshoot")) {
			case 1:
				greenshoot1.SetActive (false);
				greenshoot2.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenshoot2.GetComponent<Button> ().interactable = false;
				}
			else {
				greenshoot2.GetComponent<Button> ().interactable = true;

			}

				greenshoot3.SetActive (false);
				greenshoot4.SetActive (false);
				break;
			case 2:
				greenshoot1.SetActive (false);
				greenshoot2.SetActive (false);
				greenshoot3.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenshoot3.GetComponent<Button> ().interactable = false;
				}
			else {
				greenshoot3.GetComponent<Button> ().interactable = true;

			}
				greenshoot4.SetActive (false);
				break;
			case 3:
				greenshoot1.SetActive (false);
				greenshoot2.SetActive (false);
				greenshoot3.SetActive (false);
				greenshoot4.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greenshoot4.GetComponent<Button> ().interactable = false;
				}
			else {
				greenshoot4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				greenshoot1.SetActive (false);
				greenshoot2.SetActive (false);
				greenshoot3.SetActive (false);
				greenshoot4.SetActive (false);
				greenshootFull.SetActive (true);
				break;
			}
			switch (PlayerPrefs.GetInt ("greeninvincible")) {
			case 1:
				greeninvincible1.SetActive (false);
				greeninvincible2.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greeninvincible2.GetComponent<Button> ().interactable = false;
				}
			else {
				greeninvincible2.GetComponent<Button> ().interactable = true;

			}
				greeninvincible3.SetActive (false);
				greeninvincible4.SetActive (false);
				break;
			case 2:
				greeninvincible1.SetActive (false);
				greeninvincible2.SetActive (false);
				greeninvincible3.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greeninvincible3.GetComponent<Button> ().interactable = false;
				}
			else {
				greeninvincible3.GetComponent<Button> ().interactable = true;

			}
				greeninvincible4.SetActive (false);
				break;
			case 3:
				greeninvincible1.SetActive (false);
				greeninvincible2.SetActive (false);
				greeninvincible3.SetActive (false);
				greeninvincible4.SetActive (true);
				if (PlayerPrefs.GetInt ("greenenabled") == 0) {

					greeninvincible4.GetComponent<Button> ().interactable = false;
				}
			else {
				greeninvincible4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				greeninvincible1.SetActive (false);
				greeninvincible2.SetActive (false);
				greeninvincible3.SetActive (false);
				greeninvincible4.SetActive (false);
				greeninvincibleFull.SetActive (true);
				break;
				}
			// Yellow Dragon Panel Check
			switch (PlayerPrefs.GetInt ("yellowpower")) {
			case 1:
				yellowpower1.SetActive (false);
				yellowpower2.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowpower2.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowpower2.GetComponent<Button> ().interactable = true;

			}
				yellowpower3.SetActive (false);
				yellowpower4.SetActive (false);
				break;
			case 2:
				yellowpower1.SetActive (false);
				yellowpower2.SetActive (false);
				yellowpower3.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowpower3.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowpower3.GetComponent<Button> ().interactable = true;

			}
				yellowpower4.SetActive (false);
				break;
			case 3:
				yellowpower1.SetActive (false);
				yellowpower2.SetActive (false);
				yellowpower3.SetActive (false);
				yellowpower4.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowpower4.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowpower4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				yellowpower1.SetActive (false);
				yellowpower2.SetActive (false);
				yellowpower3.SetActive (false);
				yellowpower4.SetActive (false);
				yellowpowerFull.SetActive (true);
				break;

			}

			switch (PlayerPrefs.GetInt ("yellowspeed")) {
			case 1:
				yellowspeed1.SetActive (false);
				yellowspeed2.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowspeed2.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowspeed2.GetComponent<Button> ().interactable = true;

			}
				yellowspeed3.SetActive (false);
				yellowspeed4.SetActive (false);
				break;
			case 2:
				yellowspeed1.SetActive (false);
				yellowspeed2.SetActive (false);
				yellowspeed3.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowspeed3.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowspeed3.GetComponent<Button> ().interactable = true;

			}
				yellowspeed4.SetActive (false);
				break;
			case 3:
				yellowspeed1.SetActive (false);
				yellowspeed2.SetActive (false);
				yellowspeed3.SetActive (false);
				yellowspeed4.SetActive (true);	
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowspeed4.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowspeed4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				yellowspeed1.SetActive (false);
				yellowspeed2.SetActive (false);
				yellowspeed3.SetActive (false);
				yellowspeed4.SetActive (false);
				yellowspeedFull.SetActive (true);
				break;
			}

			switch (PlayerPrefs.GetInt ("yellowshoot")) {
			case 1:
				yellowshoot1.SetActive (false);
				yellowshoot2.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowshoot2.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowshoot2.GetComponent<Button> ().interactable = true;

			}
				yellowshoot3.SetActive (false);
				yellowshoot4.SetActive (false);
				break;
			case 2:
				yellowshoot1.SetActive (false);
				yellowshoot2.SetActive (false);
				yellowshoot3.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowshoot3.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowshoot3.GetComponent<Button> ().interactable = true;

			}

				yellowshoot4.SetActive (false);
				;
				break;
			case 3:
				yellowshoot1.SetActive (false);
				yellowshoot2.SetActive (false);
				yellowshoot3.SetActive (false);
				yellowshoot4.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowshoot4.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowshoot4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				yellowshoot1.SetActive (false);
				yellowshoot2.SetActive (false);
				yellowshoot3.SetActive (false);
				yellowshoot4.SetActive (false);
				yellowshootFull.SetActive (true);
				break;
			}
			switch (PlayerPrefs.GetInt ("yellowinvincible")) {
			case 1:
				yellowinvincible1.SetActive (false);
				yellowinvincible2.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowinvincible2.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowinvincible2.GetComponent<Button> ().interactable = true;

			}
				yellowinvincible3.SetActive (false);
				yellowinvincible4.SetActive (false);
				break;
			case 2:
				yellowinvincible1.SetActive (false);
				yellowinvincible2.SetActive (false);
				yellowinvincible3.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowinvincible3.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowinvincible3.GetComponent<Button> ().interactable = true;

			}

				yellowinvincible4.SetActive (false);
				break;
			case 3:
				yellowinvincible1.SetActive (false);
				yellowinvincible2.SetActive (false);
				yellowinvincible3.SetActive (false);
				yellowinvincible4.SetActive (true);
				if (PlayerPrefs.GetInt ("yellowenabled") == 0) {

					yellowinvincible4.GetComponent<Button> ().interactable = false;
				}
			else {
				yellowinvincible4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				yellowinvincible1.SetActive (false);
				yellowinvincible2.SetActive (false);
				yellowinvincible3.SetActive (false);
				yellowinvincible4.SetActive (false);
				yellowinvincibleFull.SetActive (true);
				
				break;
				}
			// Blue Dragon Panel Check
			switch (PlayerPrefs.GetInt ("bluepower")) {
			case 1:
				bluepower1.SetActive (false);
				bluepower2.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluepower2.GetComponent<Button> ().interactable = false;
				}
			else {
				bluepower2.GetComponent<Button> ().interactable = true;

			}
				bluepower3.SetActive (false);
				bluepower4.SetActive (false);
				break;
			case 2:
				bluepower1.SetActive (false);
				bluepower2.SetActive (false);
				bluepower3.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluepower3.GetComponent<Button> ().interactable = false;
				}
			else {
				bluepower3.GetComponent<Button> ().interactable = true;

			}
				bluepower4.SetActive (false);
				break;
			case 3:
				bluepower1.SetActive (false);
				bluepower2.SetActive (false);
				bluepower3.SetActive (false);
				bluepower4.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluepower4.GetComponent<Button> ().interactable = false;
				}
			else {
				bluepower4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				bluepower1.SetActive (false);
				bluepower2.SetActive (false);
				bluepower3.SetActive (false);
				bluepower4.SetActive (false);
				bluepowerFull.SetActive (true);
				break;

			}

			switch (PlayerPrefs.GetInt ("bluespeed")) {
			case 1:
				bluespeed1.SetActive (false);
				bluespeed2.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluespeed2.GetComponent<Button> ().interactable = false;
				}
			else {
				bluespeed2.GetComponent<Button> ().interactable = true;

			}
				bluespeed3.SetActive (false);
				bluespeed4.SetActive (false);
				break;
			case 2:
				bluespeed1.SetActive (false);
				bluespeed2.SetActive (false);
				bluespeed3.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluespeed3.GetComponent<Button> ().interactable = false;
				}
			else {
				bluespeed3.GetComponent<Button> ().interactable = true;

			}
				bluespeed4.SetActive (false);
				break;
			case 3:
				bluespeed1.SetActive (false);
				bluespeed2.SetActive (false);
				bluespeed3.SetActive (false);
				bluespeed4.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					bluespeed4.GetComponent<Button> ().interactable = false;
				}
			else {
				bluespeed4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				bluespeed1.SetActive (false);
				bluespeed2.SetActive (false);
				bluespeed3.SetActive (false);
				bluespeed4.SetActive (false);
				bluespeedFull.SetActive (true);
				break;
			}

			switch (PlayerPrefs.GetInt ("blueshoot")) {
			case 1:
				blueshoot1.SetActive (false);
				blueshoot2.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueshoot2.GetComponent<Button> ().interactable = false;
				}
			else {
				blueshoot2.GetComponent<Button> ().interactable = true;

			}
				blueshoot3.SetActive (false);
				blueshoot4.SetActive (false);
				break;
			case 2:
				blueshoot1.SetActive (false);
				blueshoot2.SetActive (false);
				blueshoot3.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueshoot3.GetComponent<Button> ().interactable = false;
				}
			else {
				blueshoot3.GetComponent<Button> ().interactable = true;

			}
				blueshoot4.SetActive (false);
				break;
			case 3:
				blueshoot1.SetActive (false);
				blueshoot2.SetActive (false);
				blueshoot3.SetActive (false);
				blueshoot4.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueshoot4.GetComponent<Button> ().interactable = false;
				}
			else {
				blueshoot4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				blueshoot1.SetActive (false);
				blueshoot2.SetActive (false);
				blueshoot3.SetActive (false);
				blueshoot4.SetActive (false);
				blueshootFull.SetActive (true);
				break;
			}
			switch (PlayerPrefs.GetInt ("blueinvincible")) {
			case 1:
				blueinvincible1.SetActive (false);
				blueinvincible2.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueinvincible2.GetComponent<Button> ().interactable = false;
				}
			else {
				blueinvincible2.GetComponent<Button> ().interactable = true;

			}
				blueinvincible3.SetActive (false);
				blueinvincible4.SetActive (false);
				break;
			case 2:
				blueinvincible1.SetActive (false);
				blueinvincible2.SetActive (false);
				blueinvincible3.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueinvincible3.GetComponent<Button> ().interactable = false;
				}
			else {
				blueinvincible3.GetComponent<Button> ().interactable = true;

			}
				blueinvincible4.SetActive (false);
				break;
			case 3:
				blueinvincible1.SetActive (false);
				blueinvincible2.SetActive (false);
				blueinvincible3.SetActive (false);
				blueinvincible4.SetActive (true);
				if (PlayerPrefs.GetInt ("blueenabled") == 0) {

					blueinvincible4.GetComponent<Button> ().interactable = false;
				}
			else {
				blueinvincible4.GetComponent<Button> ().interactable = true;

			}
				break;
			case 4:
				blueinvincible1.SetActive (false);
				blueinvincible2.SetActive (false);
				blueinvincible3.SetActive (false);
				blueinvincible4.SetActive (false);
				blueinvincibleFull.SetActive (true);
				break;
			}
	}

	public void next(string color)
	{
		switch (color) {
		case "Red":
			blueLeft.SetActive (false);
			blueRight.SetActive (false);
			blue.SetActive (false);
			bluePanel.SetActive (false);
			redLeft.SetActive (true);
			redRight.SetActive (true);
			red.SetActive (true);
			redPanel.SetActive (true);

			break;
		case "Green":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			red.SetActive (false);
			redPanel.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);

			green.SetActive (true);
			greenPanel.SetActive (true);
			break;

		case "Yellow":
			greenLeft.SetActive (false);
			greenRight.SetActive (false);
			green.SetActive (false);
			greenPanel.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);

			yellow.SetActive (true);
			yellowPanel.SetActive (true);

			break;

		case "Blue":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			yellow.SetActive (false);
			yellowPanel.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
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
			green.SetActive (false);
			greenPanel.SetActive (false);
			redLeft.SetActive (true);
			redRight.SetActive (true);
			red.SetActive (true);
			redPanel.SetActive (true);

			break;

		case "Green":
			yellowLeft.SetActive (false);
			yellowRight.SetActive (false);
			yellow.SetActive (false);
			yellowPanel.SetActive (false);

			greenLeft.SetActive (true);
			greenRight.SetActive (true);

			green.SetActive (true);
			greenPanel.SetActive (true);
			break;

		case "Yellow":
			blueLeft.SetActive (false);
			blueRight.SetActive (false);
			blue.SetActive (false);
			bluePanel.SetActive (false);

			yellowLeft.SetActive (true);
			yellowRight.SetActive (true);
			yellow.SetActive (true);
			yellowPanel.SetActive (true);
			break;

		case "Blue":
			redLeft.SetActive (false);
			redRight.SetActive (false);
			red.SetActive (false);
			redPanel.SetActive (false);

			blueLeft.SetActive (true);
			blueRight.SetActive (true);
			blue.SetActive (true);
			bluePanel.SetActive (true);
			break;
		}
	}
}
