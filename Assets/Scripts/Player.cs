using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {



	private	LevelBoundarySetup 	LevelBoundarySetup;
	private _GC 			_GC;
//	private	Enemy 			Enemy;
	private	Rigidbody2D		playerRB;
	private	VirtualJoystick joystick;
	private	Animator		playerAnimator;
	private	Transform 		Top, Down, Left, Right;
	private	string[] 		shoot;
	private GameObject 		Friend1, Friend2;
	private int damageShootEnemy, damageEnemyValue,powerUps;
	public int 			index;
	public	Transform		spawnPlayer,spawnFriend1,spawnFriend2;
	public	float			scale;
	public	float			percLife;
	public	float			speed, shootForce;
	public  Transform 		playerShoot;
	public	GameObject[] 	prefabShoot;
	public	GameObject		prefabParticles,Friend1Prefab,Friend2Prefab;
	public	float			HP,HPMax;
	public 	bool 			dead, firstAlive,secondAlive;
	public	int 			damage,extraLifes,damageShoot1,damageShoot2,damageShoot3,damageShoot4,Friends;
	public	string 			Shoot;


	// Use this for initialization
	void Start () {

		LevelBoundarySetup = FindObjectOfType (typeof(LevelBoundarySetup)) as LevelBoundarySetup;
//		Top = LevelBoundarySetup.Top;
//		Bottom = LevelBoundarySetup.Bottom;
//		Left = LevelBoundarySetup.Left;
//		Right = LevelBoundarySetup.Right;

		Shoot = PlayerPrefs.GetString ("shoot");
		if (string.IsNullOrEmpty(Shoot))
		{
			PlayerPrefs.SetString ("shoot", "playerShoot1");
		}
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
//		Enemy = FindObjectOfType (typeof(Enemy)) as Enemy;
//		PlayerFriend = FindObjectOfType (typeof(PlayerFriend)) as PlayerFriend;
		HP = HPMax;
		dead = false;
		playerRB = GetComponent<Rigidbody2D> ();	
		joystick = FindObjectOfType (typeof(VirtualJoystick)) as VirtualJoystick;
//		Top = GameObject.Find ("Top").transform;
//		Down = GameObject.Find ("Down").transform;
//		Left = GameObject.Find ("Left").transform;
//		Right = GameObject.Find ("Right").transform;
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

			if (transform.position.x < LevelBoundarySetup.leftBoundary.transform.position.x) {
				transform.position = new Vector3 (LevelBoundarySetup.leftBoundary.transform.position.x, transform.position.y, transform.position.z);
			} else if (transform.position.x > LevelBoundarySetup.rightBoundary.transform.position.x) {
				transform.position = new Vector3 (LevelBoundarySetup.rightBoundary.transform.position.x, transform.position.y, transform.position.z);
			} 


			if (transform.position.y < LevelBoundarySetup.bottomBoundary.transform.position.y) {
				transform.position = new Vector3 (transform.position.x, LevelBoundarySetup.bottomBoundary.transform.position.y, transform.position.z);
			} else if (transform.position.y > LevelBoundarySetup.topBoundary.transform.position.y) {
				transform.position = new Vector3 (transform.position.x, LevelBoundarySetup.topBoundary.transform.position.y, transform.position.z);

			}
		} 
	}

	void Fire()
	{
			index = chooseShoot (Shoot);
			GameObject tempPrefab = Instantiate (prefabShoot[index]) as GameObject;
			tempPrefab.transform.position = playerShoot.position;
			tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));
			if (firstAlive) {
				Friend1.SendMessage ("Fire", SendMessageOptions.DontRequireReceiver);
			}
			if (secondAlive) {
				Friend2.SendMessage ("Fire", SendMessageOptions.DontRequireReceiver);
			}


	}
	public void damageEnemy(int damage)
	{
	
		damageEnemyValue = damage;

	}
	public void shootEnemy(int shootDamage)
	{
		damageShootEnemy = shootDamage;


	}
	public void FriendDestroyed(string name)
	{
		Friends -= 1;
		switch (name) {
		case "Friend1":
			firstAlive = false;
			break;
		case "Friend2":
			secondAlive = false;
			break;
		}
	}

	void AddFriends(GameObject GO)
	{
		Friends += 1;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);

		if (Friends == 2 && secondAlive) {
			firstAlive = true;
			Friend1 = Instantiate (Friend1Prefab);
			Friend1.transform.SetParent (transform);
			Friend1.transform.position = spawnFriend1.position;
		}
		if (!firstAlive && Friends == 1){
			firstAlive = true;
			Friend1 = Instantiate (Friend1Prefab);
			Friend1.transform.SetParent (transform);
			Friend1.transform.position = spawnFriend1.position;
		}
		if (!secondAlive && Friends == 2) {
			secondAlive = true;
			Friend2 = Instantiate (Friend2Prefab);
			Friend2.transform.SetParent (transform);
			Friend2.transform.position = spawnFriend2.position;
		}
	}

	public int chooseShoot(string shoot)
	{
		switch (shoot)
		{
		case "playerShoot1":
			index = 0;
			break;
		case "playerShoot2":
			index = 1;
			break;
		case "playerShoot3":
			index = 2;
			break;
		case "playerShoot4":
			index = 3;
			break;

		}
		return index;
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
				takeDamage (damageEnemyValue);
				break;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!dead) {
			
			switch (col.gameObject.tag) {
			case "Enemy":
				takeDamage (damageEnemyValue);
				break;
			case "enemyShoot":
				takeDamage (damageShootEnemy);	
				break;
			case "powerup":
				powerup (col.gameObject);
				break;
			case "FriendItem":
				AddFriends (col.gameObject);
				break;
			case "coin":
				coin (col.gameObject);
				break;
			case "life":
				life (col.gameObject);
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
		Friends = 0;
		if (firstAlive) {
			Destroy (Friend1);
		} 
		if (secondAlive) {
			Destroy (Friend2);
		}
		firstAlive = false;
		secondAlive = false;
		_GC.UpdateHPBar (percLife);
		extraLifes -= 1;
		_GC.extraLifes = extraLifes;
		if (extraLifes <= 0) {
			dead = true;
			playerAnimator.SetBool ("dead", true);
			playerRB.velocity = new Vector2 (0.3f * speed, 0.3f * speed);
			playerRB.IsSleeping ();
			StartCoroutine ("Died");
			Shoot = PlayerPrefs.GetString ("shoot");
		} else {
			dead = false;
			_GC.StartHPBar ();
			HP = HPMax;
			percLife = (HP / HPMax);

			transform.position = spawnPlayer.transform.position;
			Shoot = PlayerPrefs.GetString ("shoot");

		}

	}
	void powerup(GameObject GO)
	{
		powerUps++;
		_GC.points += 100 * powerUps;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
		HP = HPMax;
		percLife = 1;
		_GC.UpdateHPBar (percLife);
		switch (Shoot) {
		case "playerShoot1":
			Shoot = "playerShoot2";
			break;
		case "playerShoot2":
			Shoot = "playerShoot3";
			break;
		case "playerShoot3":
			Shoot = "playerShoot4";
			break;
		case "playerShoot4":
			Shoot = "playerShoot4";
			break;
		}
	}

	void coin(GameObject GO)
	{
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
	}

	void life(GameObject GO)
	{
		extraLifes++;
		_GC.extraLifes = extraLifes;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
	}
}
