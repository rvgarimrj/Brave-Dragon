using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

//	public class LevelBoundary
//	{
//		readonly Camera camera;
//
//		public LevelBoundary(Camera camera)
//		{
//			this.camera = camera;
//		}
//
//		public float Bottom
//		{
//			get { return -ExtentHeight; }
//		}
//
//		public float Top
//		{
//			get { return ExtentHeight; }
//		}
//
//		public float Left
//		{
//			get { return -ExtentWidth; }
//		}
//
//		public float Right
//		{
//			get { return ExtentWidth; }
//		}
//
//		public float ExtentHeight
//		{
//			get { return camera.orthographicSize; }
//		}
//
//		public float Height
//		{
//			get { return ExtentHeight * 2.0f; }
//		}
//
//		public float ExtentWidth
//		{
//			get { return camera.aspect * camera.orthographicSize; }
//		}
//
//		public float Width
//		{
//			get { return ExtentWidth * 2.0f; }
//		}
//	}

	private _GC 			_GC;
	private	Enemy 			Enemy;
	private	Rigidbody2D		playerRB;
	private	VirtualJoystick joystick;
	private	Animator		playerAnimator;
	private	Transform 		Top, Down, Left, Right;

	public	Transform		spawnPlayer;
	public	float			scale;
	public	float			percLife;
	public	float			speed, shootForce;
	public  Transform 		playerShoot;
	public	GameObject 		prefabShoot,prefabParticles;
	public	float			HP,HPMax;
	public 	bool 			dead;
	public	int 			damage,extraLifes,damageShoot1,damageShoot2,damageShoot3,damageShoot4;


	// Use this for initialization
	void Start () {

		_GC = FindObjectOfType (typeof(_GC)) as _GC;
		Enemy = FindObjectOfType (typeof(Enemy)) as Enemy;

		// Set HP Bar to 100% and save original scale

//		theScale = barraHP.localScale;
//		scale = theScale.x;
		HP = HPMax;
//		transform.position = spawnPlayer.transform.position;

//		percLife = (HP / HPMax);
//		theScale.x = percLife * scale;
//		barraHP.localScale = theScale;

		// 

		dead = false;
		playerRB = GetComponent<Rigidbody2D> ();	
		joystick = FindObjectOfType (typeof(VirtualJoystick)) as VirtualJoystick;
		Top = GameObject.Find ("Top").transform;
		Down = GameObject.Find ("Down").transform;
		Left = GameObject.Find ("Left").transform;
		Right = GameObject.Find ("Right").transform;
		playerAnimator = GetComponent<Animator> ();

//		Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(50, 50, 0));
//		Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width -50, Screen.height -50, 0));
//		print (minScreenBounds);
//		print (maxScreenBounds);
//		Left.transform.position = minScreenBounds;
//		Right.transform.position = maxScreenBounds;
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

		if (!dead) {
			

			if (Input.GetButtonDown ("Fire")) {
				Fire ();
			}
			float x = joystick.Horizontal ();
			float y = joystick.Vertical ();

			//  Uncomment to make movements more quickly

//			if (x < 0) {
//				x = -1;
//			} else if (x > 0) {
//				x = 1;
//			}
//		
//			if (y < 0) {
//				y = -1;
//			} else if (x > 0) {
//				y = 1;
//			}

			playerRB.velocity = new Vector2 (x * speed, y * speed);
			// Camera limits the Player

			if (transform.position.x < Left.position.x) {
				transform.position = new Vector3 (Left.position.x, transform.position.y, transform.position.z);
			} else if (transform.position.x > Right.position.x) {
				transform.position = new Vector3 (Right.position.x, transform.position.y, transform.position.z);
			} 


			if (transform.position.y < Down.position.y) {
				transform.position = new Vector3 (transform.position.x, Down.position.y, transform.position.z);
			} else if (transform.position.y > Top.position.y) {
				transform.position = new Vector3 (transform.position.x, Top.position.y, transform.position.z);

			}
		} 
	}

	void Fire()
	{

			GameObject tempPrefab = Instantiate (prefabShoot) as GameObject;
			tempPrefab.transform.position = playerShoot.position;
			tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));

	}


	IEnumerator Died()
	{
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
		SceneManager.LoadScene ("gameover");
	}

	IEnumerator	Dizzy()
	{
		yield return new WaitForSeconds (0.6f);
		playerAnimator.SetBool ("dizzy", false);


	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (!dead) {
			
			switch (col.gameObject.tag) {
			case "Enemy":
				takeDamage (Enemy.damage);
				break;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!dead) {
			
			switch (col.gameObject.tag) {

			case "enemyShoot1":
				takeDamage (Enemy.damageShoot1);	
				break;
			case "powerup":
				powerup (col.gameObject);

				break;
	
			}
		}
	}

	void takeDamage (int damage)
	{
			HP -= damage;
			percLife = (HP / HPMax);
			if (HP <= 0) {
				DieOrRestart ();

			} else {
				_GC.UpdateHPBar (percLife);
				playerAnimator.SetBool ("dizzy", true);
				StartCoroutine ("Dizzy");
			}
	}

	void DieOrRestart()
	{
		percLife = 0;
		_GC.UpdateHPBar (percLife);
		extraLifes -= 1;
		_GC.extraLifes = extraLifes;
		if (extraLifes <= 0) {
			dead = true;
			playerAnimator.SetBool ("dead", true);
			playerRB.velocity = new Vector2 (0.3f * speed, 0.3f * speed);
			playerRB.IsSleeping ();
			StartCoroutine ("Died");



		} else {
			dead = false;
			_GC.StartHPBar ();
			HP = HPMax;
			percLife = (HP / HPMax);

			transform.position = spawnPlayer.transform.position;

		}

	}
	void powerup(GameObject GO)
	{
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
	}
}
