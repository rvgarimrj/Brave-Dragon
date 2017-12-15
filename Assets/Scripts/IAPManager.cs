using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener {
	private _GC_TXT _GC_TXT;
	public static IAPManager Instance;
	public static IStoreController 		m_storeController;
	public static IExtensionProvider	m_storeExtensionProvider;

	public Text p_500coins, p_1500coins,p_3000coins,p_5000coins,p_3keys,p_5keys,p_unlockall,coins_TXT,txt_500coins,txt_1500coins,txt_3000coins,txt_5000coins,txt_3keys,txt_5keys,txt_unlockall,keys_txt;
	// Product List -----------

	public static string product500coins = "500coins";
	public static string product1500coins = "1500coins";
	public static string product3000coins = "3000coins";
	public static string product5000coins = "5000coins";
	public static string product3keys = "3keys";
	public static string product5keys = "5keys";
	public static string productunlockall = "unlockall";
	private int coins,keys;
	// ------------------------
	void Awake()

	{
//		coins_TXT = GameObject.Find ("coins_TXT_buy").GetComponent<Text> ();
//
//		p_500coins = GameObject.Find ("p_500coins").GetComponent<Text> ();
//		txt_500coins = GameObject.Find ("txt_500coins").GetComponent<Text> ();
//
//		p_1500coins = GameObject.Find ("p_1500coins").GetComponent<Text> ();
//		txt_1500coins = GameObject.Find ("txt_1500coins").GetComponent<Text> ();
//
//		p_3000coins = GameObject.Find ("p_3000coins").GetComponent<Text> ();
//		txt_3000coins = GameObject.Find ("txt_3000coins").GetComponent<Text> ();
//
//		p_5000coins = GameObject.Find ("p_5000coins").GetComponent<Text> ();
//		txt_5000coins = GameObject.Find ("txt_5000coins").GetComponent<Text> ();
//
//		p_3keys = GameObject.Find ("p_3keys").GetComponent<Text> ();
//		txt_3keys = GameObject.Find ("txt_3keys").GetComponent<Text> ();
//
//		p_5keys = GameObject.Find ("p_5keys").GetComponent<Text> ();
//		txt_5keys = GameObject.Find ("txt_5keys").GetComponent<Text> ();
//
//		p_unlockall = GameObject.Find ("p_unlockall").GetComponent<Text> ();
//		txt_unlockall = GameObject.Find ("txt_unlockall").GetComponent<Text> ();

//		if (Instance == null) {
//			Instance = this;
//			DontDestroyOnLoad (gameObject);
//		} else {
//			Destroy (gameObject);
//		}
	}
	// Use this for initialization
	void Start () {

		_GC_TXT = FindObjectOfType (typeof(_GC_TXT)) as _GC_TXT;

		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString();
		keys_txt.text = PlayerPrefs.GetInt ("keys").ToString();
		if (!IsInitialized()) {
			InitializePurchasing ();
		}
		InitializePrices ();
	}

	void InitializePrices()
	{
		p_500coins.text = m_storeController.products.WithID (product500coins).metadata.localizedPriceString;
		txt_500coins.text = m_storeController.products.WithID (product500coins).metadata.localizedDescription;

		p_1500coins.text = m_storeController.products.WithID (product1500coins).metadata.localizedPriceString;
		txt_1500coins.text = m_storeController.products.WithID (product1500coins).metadata.localizedDescription;

		p_3000coins.text = m_storeController.products.WithID (product3000coins).metadata.localizedPriceString;
		txt_3000coins.text = m_storeController.products.WithID (product3000coins).metadata.localizedDescription;

		p_5000coins.text = m_storeController.products.WithID (product5000coins).metadata.localizedPriceString;
		txt_5000coins.text = m_storeController.products.WithID (product5000coins).metadata.localizedDescription;

		p_3keys.text = m_storeController.products.WithID (product3keys).metadata.localizedPriceString;
		txt_3keys.text = m_storeController.products.WithID (product3keys).metadata.localizedDescription;

		p_5keys.text = m_storeController.products.WithID (product5keys).metadata.localizedPriceString;
		txt_5keys.text = m_storeController.products.WithID (product5keys).metadata.localizedDescription;

		p_unlockall.text = m_storeController.products.WithID (productunlockall).metadata.localizedPriceString;
		txt_unlockall.text = m_storeController.products.WithID (productunlockall).metadata.localizedDescription;



	}
	public void InitializePurchasing()
	{
		if (IsInitialized()) {
			return;
		}
		StandardPurchasingModule module = StandardPurchasingModule.Instance ();
		ConfigurationBuilder builder = ConfigurationBuilder.Instance (module);

		builder.AddProduct (product500coins, ProductType.Consumable);
		builder.AddProduct (product1500coins, ProductType.Consumable);
		builder.AddProduct (product3000coins, ProductType.Consumable);
		builder.AddProduct (product5000coins, ProductType.Consumable);
		builder.AddProduct (product3keys, ProductType.Consumable);
		builder.AddProduct (product5keys, ProductType.Consumable);
		builder.AddProduct (productunlockall , ProductType.NonConsumable);

		UnityPurchasing.Initialize (this, builder);

	}
	// Update is called once per frame
	void Update () {
		coins_TXT.text = PlayerPrefs.GetInt ("coins").ToString();
		keys_txt.text = PlayerPrefs.GetInt ("keys").ToString();
		InitializePrices ();
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		m_storeController = controller;
		m_storeExtensionProvider = extensions;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("DEBUG: IAPMANAGER OnInitializeFailed Error: " + error);
	}

	private bool IsInitialized()
	{
		return m_storeController != null && m_storeExtensionProvider != null;
	}

	public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
	{
		Debug.Log ("DEBUG: OnPurchaseFailed for Product " + i.definition.id + " ERROR: " + p);
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
	{
		string productId = e.purchasedProduct.definition.id;
		if (productId == product500coins) {
			coins = PlayerPrefs.GetInt ("coins");
			coins += 500;
			PlayerPrefs.SetInt ("coins", coins);

		} else if (productId == product1500coins) {
			coins = PlayerPrefs.GetInt ("coins");
			coins += 1500;
			PlayerPrefs.SetInt ("coins", coins);


		} else if (productId == product3000coins) {
			coins = PlayerPrefs.GetInt ("coins");
			coins += 3000;
			PlayerPrefs.SetInt ("coins", coins);

		} 
		else if (productId == product5000coins) {
			coins = PlayerPrefs.GetInt ("coins");
			coins += 5000;
			PlayerPrefs.SetInt ("coins", coins);

		}
		else if (productId == product3keys) {
			keys = PlayerPrefs.GetInt ("keys");
			keys += 3;
			PlayerPrefs.SetInt ("keys", keys);

		}
		else if (productId == product5keys) {
			keys = PlayerPrefs.GetInt ("keys");
			keys += 5;
			PlayerPrefs.SetInt ("keys", keys);

		}

		else if (productId == productunlockall) {
			PlayerPrefs.SetInt ("greenenabled", 1);
			PlayerPrefs.SetInt ("yellowenabled", 1);
			PlayerPrefs.SetInt ("blueenabled", 1);

			PlayerPrefs.SetInt ("redpower", 4);
			PlayerPrefs.SetInt ("redspeed", 4);
			PlayerPrefs.SetInt ("redshoot", 4);
			PlayerPrefs.SetInt ("redinvincible", 4);

			PlayerPrefs.SetInt ("greenpower", 4);
			PlayerPrefs.SetInt ("greenspeed", 4);
			PlayerPrefs.SetInt ("greenshoot", 4);
			PlayerPrefs.SetInt ("greeninvincible", 4);

			PlayerPrefs.SetInt ("yellowpower", 4);
			PlayerPrefs.SetInt ("yellowspeed", 4);
			PlayerPrefs.SetInt ("yellowshoot", 4);
			PlayerPrefs.SetInt ("yellowinvincible", 4);

			PlayerPrefs.SetInt ("bluepower", 4);
			PlayerPrefs.SetInt ("bluespeed", 4);
			PlayerPrefs.SetInt ("blueshoot", 4);
			PlayerPrefs.SetInt ("blueinvincible", 4);

			GlobalFunctions.achieviments ("greenplayerunlock");
			GlobalFunctions.achieviments ("yellowplayerunlock");
			GlobalFunctions.achieviments ("blueplayerunlock");
		}
		return PurchaseProcessingResult.Complete;
	}

	public void BuyProductID(string productId)
	{
		if (IsInitialized ()) {
			Product product = m_storeController.products.WithID (productId);
			if (product != null && product.availableToPurchase) {
				m_storeController.InitiatePurchase (product);
				Debug.Log ("DEBUG: BuyProductID " + product.definition.id + " - " + product.metadata.localizedPriceString);

			} else {
				Debug.Log ("DEBUG: BuyProductID " + productId + " NOT FOUND");
			}
		} else {
			Debug.Log ("DEBUG: BuyProductID ERROR " + productId + "LOJA NAO INICIALIZADA");
		}
	}

	public void Sell500coins()
	{
		BuyProductID (product500coins);
	}

	public void Sell1500coins()
	{
		BuyProductID (product1500coins);
	}
	public void Sell3000coins()
	{
		BuyProductID (product3000coins);
	}
	public void Sell5000coins()
	{
		BuyProductID (product5000coins);
	}
	public void Sell3keys()
	{
		BuyProductID (product3keys);
	}
	public void Sell5keys()
	{
		BuyProductID (product5keys);
	}
	public void SellUnlockAll()
	{
		BuyProductID (productunlockall);
	}
}
