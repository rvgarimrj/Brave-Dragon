using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener {
	public static IAPManager Instance;
	public static IStoreController 		m_storeController;
	public static IExtensionProvider	m_storeExtensionProvider;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions);

	public void OnInitializeFailed(InitializationFailureReason error);

	public void OnPurchaseFailed(Product i, PurchaseFailureReason p);

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e);
}
