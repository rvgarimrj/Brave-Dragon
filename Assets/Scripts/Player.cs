using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	private	Rigidbody2D		playerRB;
	private	VirtualJoystick joystick;
	private	Animator		playerAnimator;

	public	float			speed, shootForce,Fade;
	public	Transform		Top, Down, Left, Right,playerShoot;
	public 	Camera			mainCamera;
	public	GameObject 		prefabShoot;

	public Color spriteColor = Color.white;
	public float fadeInTime = 1.5f;
	public float fadeOutTime = 3f;
	public float delayToFadeOut = 5f;
	public float delayToFadeIn = 5f;

	public SpriteRenderer Sprite;


	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody2D> ();	
		joystick = FindObjectOfType (typeof(VirtualJoystick)) as VirtualJoystick;
		Top = GameObject.Find ("Top").transform;
		Down = GameObject.Find ("Down").transform;
		Left = GameObject.Find ("Left").transform;
		Right = GameObject.Find ("Right").transform;
		playerAnimator = GetComponent<Animator> ();

		Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(50, 50, 0));
		Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width -50, Screen.height -50, 0));
		print (minScreenBounds);
		print (maxScreenBounds);
		Left.transform.position = minScreenBounds;
		Right.transform.position = maxScreenBounds;
//		Left.transform.position.x += 1;
//		Right.transform.position.x -= 1;
//		Left.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);

//		int meioTela = Screen.width / 2;
//		Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(meioTela, 0, 0));
//
//		print (worldPos.x);
//		print (worldPos.y);
//		print (worldPos.z);
//
//		Left.position = new Vector3(worldPos.y * -1 - 1.5f, 0, 0);
//		Right.position = new Vector3(worldPos.y - 1.5f, 0,0);

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetButtonDown("Fire")) {
			Fire ();
		}
		float x = joystick.Horizontal ();
		float y = joystick.Vertical ();
				if (x < 0) {
					x = -1;
				} else if (x > 0) {
					x = 1;
				}
		
				if (y < 0) {
					y = -1;
				} else if (x > 0) {
					y = 1;
				}

		playerRB.velocity = new Vector2 (x * speed, y * speed);
		// Camera limits the Player

		if (transform.position.x < Left.position.x) {
			transform.position = new Vector3 (Left.position.x, transform.position.y, transform.position.z);
		} else if (transform.position.x > Right.position.x) {
			transform.position = new Vector3 (Right.position.x, transform.position.y, transform.position.z);
		} 


		if (transform.position.y < Down.position.y) {
			transform.position = new Vector3 (transform.position.x, Down.position.y, transform.position.z);
		}
		else if (transform.position.y > Top.position.y) {
			transform.position = new Vector3 (transform.position.x, Top.position.y, transform.position.z);

		}
	}

	void Fire()
	{
		// Set shoot animation
//		playerAnimator.SetBool("shoot",true);
		// Fire

		GameObject tempPrefab = Instantiate (prefabShoot) as GameObject;
		tempPrefab.transform.position = playerShoot.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));

//		 StartCoroutine ("count");


	}

	public void FadeOut()
	{
		StartCoroutine("FadeCycle");
	}

	IEnumerator FadeCycle()
	{
		float fade = 0f;
		float startTime;
		while(true)
		{
			startTime = Time.time;
			while(fade < 1f)
			{
				fade = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeInTime);
				spriteColor.a = fade;
				Sprite.color = spriteColor;
				yield return null;
			}
			//Make sure it's set to exactly 1f
			fade = 1f;
			spriteColor.a = fade;
			Sprite.color = spriteColor;
			yield return new WaitForSeconds(delayToFadeOut);

			startTime = Time.time;
			while(fade > 0f)
			{
				fade = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeOutTime);
				spriteColor.a = fade;
				Sprite.color = spriteColor;
				yield return null;
			}
			fade = 0f;
			spriteColor.a = fade;
			Sprite.color = spriteColor;
			yield return new WaitForSeconds(delayToFadeIn);
		}
	}


	IEnumerator	count()
	{
		yield return new WaitForSeconds (0.1f);
		playerAnimator.SetBool("shoot",false);

	}

}
