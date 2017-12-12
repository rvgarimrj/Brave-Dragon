using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener {
	public static IAPManager Instance;
	public static IStoreController 		m_storeController;
	public static IExtensionProvider	m_storeExtensionProvider;
	[SerializeField]
	private Text p1, p2, p3;
	// Product List -----------

	public static string product1000coins = "1000coins";
	public static string product5000coins = "5000coins";
	public static string productunlockall = "unlockall";

	// ------------------------
	void Awake()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		if (!IsInitialized()) {
			InitializePurchasing ();
		}
		InitializePrices ();
	}
	void InitializePrices()
	{
		p1.text = m_storeController.products.WithID (product1000coins).metadata.localizedPriceString;
		p2.text = m_storeController.products.WithID (product5000coins).metadata.localizedPriceString;
		p3.text = m_storeController.products.WithID (productunlockall).metadata.localizedPriceString;
	}
	public void InitializePurchasing()
	{
		if (IsInitialized()) {
			return;
		}
		StandardPurchasingModule module = StandardPurchasingModule.Instance ();
		ConfigurationBuilder builder = ConfigurationBuilder.Instance (module);

		builder.AddProduct (product1000coins, ProductType.Consumable);
		builder.AddProduct (product5000coins, ProductType.Consumable);
		builder.AddProduct (productunlockall , ProductType.NonConsumable);

		UnityPurchasing.Initialize (this, builder);

	}
	// Update is called once per frame
	void Update () {
		
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
		if (productId == product1000coins) {

		}
		else if (productId == product5000coins) {

		}
		else if (productId == productunlockall) {

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

	public void Sell1000Coins()
	{
		BuyProductID (product1000coins);
	}

	public void Sell5000Coins()
	{
		BuyProductID (product5000coins);
	}

	public void SellUnlockAll()
	{
		BuyProductID (productunlockall);
	}
}
