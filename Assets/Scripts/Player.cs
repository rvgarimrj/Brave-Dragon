using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour {


	private	Collider2D playerCollider;
	private	LevelBoundarySetup 	LevelBoundarySetup;
	private _GC 				_GC;
//	private	Enemy 			Enemy;
	private	Rigidbody2D		playerRB;
	private	VirtualJoystick joystick;
	private	Animator			playerAnimator;
	private	Transform 		Top, Down, Left, Right;
	private	string[] 		shoot;
	private GameObject 		Friend1, Friend2;
	private int 				damageShootEnemy,powerUps,countdown,indexFriend;
	private string				sound;
//	private AudioSource soundTrack;
	private float 				volume;
	private Text				invencibleTxt;
	public int 					coins,total_coins,diamonds,coin_value;
	public int 					index;
	public	GameObject		spawnPlayer,spawnFriend1,spawnFriend2;
	public	float				scale;
	public	float				percLife;
	public	float				speed, shootForce,speed_ant;
	public  Transform 		playerShoot;
	public	GameObject[] 	prefabShoot;
	public	GameObject		prefabParticles;
	public	float				HP,HPMax;
	public 	bool 				firstAlive,secondAlive,killall;
	public	int 				damage,damageShoot1,damageShoot2,damageShoot3,damageShoot4,Friends;
	public	string 			Shoot;
	public  AudioClip 		audioCoins,audioItens;
	private string[]			shootNames = new string[]{"playerShoot1","playerShoot2","playerShoot3","playerShoot4"};
	private int[] 				powerValues = new int[]{10,15,18,20};
	private float[]			speedValues = new float[]{2.5f,2.8f,3.2f,3.5f};
	private int[]				invincibleValues = new int[]{5,8,10,12};		
	[SerializeField] private GameObject[] Friend1Prefab,Friend2Prefab;
	[SerializeField] private float percSpeed;

	// Use this for initialization
	void Start () {

//		extraLifes = GlobalVariables.extralifes;
		GlobalVariables.enemySpeed = ((speed * percSpeed) / 100);
		InitiateVariables ();
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
		HP = HPMax;
		GlobalVariables.dead = false;
		GlobalVariables.isInvencible = false;
		GlobalVariables.paused = false;
		playerRB = GetComponent<Rigidbody2D> ();	
		playerCollider = GetComponent<Collider2D> ();
		joystick = FindObjectOfType (typeof(VirtualJoystick)) as VirtualJoystick;
		playerAnimator = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		if (!GlobalVariables.dead & !GlobalVariables.paused && !Advertisement.isShowing) {
			sound = PlayerPrefs.GetString ("music");

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
	string WhichShoot(int index)
	{
		return shootNames [index - 1];
	}

	int WhichPower(int index)
	{
		return powerValues [index - 1];
	}

	float WhichSpeed(int index)
	{
		return speedValues [index - 1];
	}
	int WhichTime(int index)
	{
		return invincibleValues [index -1];
	}
	public void SpeedUp(float speed_value)
	{
		speed = speed + speed_value;
	}

	
	void InitialShoot()
	{
		if (PlayerPrefs.GetString ("playercolor") == "red") {
			countdown = WhichTime(PlayerPrefs.GetInt ("redinvincible")) ;
			Shoot = WhichShoot(PlayerPrefs.GetInt ("redshoot"));
			speed = WhichSpeed(PlayerPrefs.GetInt("redspeed"));
			HPMax = WhichPower (PlayerPrefs.GetInt ("redpower"));

		}

		// Green Player Variable settings

		if (PlayerPrefs.GetString ("playercolor") == "green") {
			countdown = WhichTime(PlayerPrefs.GetInt ("greeninvincible"));
			Shoot = WhichShoot(PlayerPrefs.GetInt ("greenshoot"));
			speed = WhichSpeed(PlayerPrefs.GetInt("greenspeed"));
			HPMax = WhichPower (PlayerPrefs.GetInt ("greenpower"));

		}

		// Blue Player Variable settings

		if (PlayerPrefs.GetString ("playercolor") == "blue") {
			countdown = WhichTime(PlayerPrefs.GetInt ("blueinvincible"));
			Shoot = WhichShoot(PlayerPrefs.GetInt ("blueshoot"));
			speed = WhichSpeed(PlayerPrefs.GetInt("bluespeed"));
			HPMax = WhichPower (PlayerPrefs.GetInt ("bluepower"));


		}

		// Yellow Player Variable settings


		if (PlayerPrefs.GetString ("playercolor") == "yellow") {
			countdown = WhichTime(PlayerPrefs.GetInt ("yellowinvincible"));
			Shoot = WhichShoot(PlayerPrefs.GetInt ("yellowshoot"));
			speed = WhichSpeed(PlayerPrefs.GetInt("yellowspeed"));
			HPMax = WhichPower (PlayerPrefs.GetInt ("yellowpower"));
		
		}

		if (GlobalVariables.powerup == 1) {
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
				damageShoot4++;
				break;
			}
		}
		if (GlobalVariables.powerup == 2) {
			switch (Shoot) {
			case "playerShoot1":
				Shoot = "playerShoot3";
				break;
			case "playerShoot2":
				Shoot = "playerShoot4";
				break;
			case "playerShoot3":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			case "playerShoot4":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			}
		}
		if (GlobalVariables.powerup > 2) {
			switch (Shoot) {
			case "playerShoot1":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			case "playerShoot2":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			case "playerShoot3":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			case "playerShoot4":
				Shoot = "playerShoot4";
				damageShoot4++;
				break;
			}
		}

	}

	void InitiateVariables()
	{
		volume = 5;
		Friends = 0;
		sound = PlayerPrefs.GetString ("music");
		spawnPlayer = GameObject.Find ("SpawnPlayer");
//		invencibleTxt = GameObject.Find ("invencibleTime").GetComponent<Text>();
//		soundTrack = GetComponent<AudioSource> ();
//		if (sound == "on") {
//			soundTrack.Play ();
//		}
		GlobalVariables.coins = 1;
		total_coins = PlayerPrefs.GetInt ("coins");
		LevelBoundarySetup = FindObjectOfType (typeof(LevelBoundarySetup)) as LevelBoundarySetup;

		// Red Player Variables settings
		InitialShoot();

	}
	public void PlaySound(){
//		soundTrack.Play ();
	}

	public void PauseSound(){
//		soundTrack.Pause ();

	}

	public void StopSound()
	{
//		soundTrack.Stop ();
	}
	public void Fire()
	{	
		if (!GlobalVariables.dead & !GlobalVariables.paused) {
			index = chooseShoot (Shoot);
			GameObject tempPrefab = Instantiate (prefabShoot [index]) as GameObject;
			tempPrefab.transform.position = playerShoot.position;
			tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));
			if (firstAlive) {
				Friend1.SendMessage ("Fire", SendMessageOptions.DontRequireReceiver);
			}
			if (secondAlive) {
				Friend2.SendMessage ("Fire", SendMessageOptions.DontRequireReceiver);
			}
		}
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
			Destroy (Friend1);
			break;
		case "Friend2":
			secondAlive = false;
			Destroy (Friend2);

			break;
		}
	}

	void AddFriends(GameObject GO)
	{
		switch (GO.name) {
		case "redItem":
			indexFriend = 0;
			break;
		case "greenItem":
			indexFriend = 1;
			break;
		case "blueItem":
			indexFriend = 2;
			break;
		case "yellowItem":
			indexFriend = 3;
			break;
		}

      	Friends += 1;
		HP += 5;
		if (HP > HPMax) {
			HP = HPMax;
			percLife = 1;
			_GC.UpdateHPBar (percLife);
		}
		GlobalVariables.points += 200;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);

		if (Friends == 2 && secondAlive) {
			firstAlive = true;
			Friend1 = Instantiate (Friend1Prefab[indexFriend]);
			Friend1.transform.SetParent (transform);
			Friend1.transform.position = spawnFriend1.transform.position;
		}
		if (!firstAlive && Friends == 1){
			firstAlive = true;
			Friend1 = Instantiate (Friend1Prefab[indexFriend]);
			Friend1.transform.SetParent (transform);
			Friend1.transform.position = spawnFriend1.transform.position;

		}
		if (!secondAlive && Friends == 2) {
			secondAlive = true;
			Friend2 = Instantiate (Friend2Prefab[indexFriend]);
			Friend2.transform.SetParent (transform);
			Friend2.transform.position = spawnFriend2.transform.position;

		}
		if (GlobalVariables.isInvencible) {
			if (firstAlive) {
				Friend1.SetActive (false);
			}
			if (secondAlive) {

				Friend2.SetActive (false);
			}
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




	IEnumerator	Dizzy()
	{
		yield return new WaitForSeconds (0.6f);
		playerAnimator.SetBool ("dizzy", false);


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!GlobalVariables.dead) {
			
			switch (col.gameObject.tag) {
			case "enemyShoot":
				takeDamage (damageShootEnemy);	
				break;
			case "powerup":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				powerup (col.gameObject);
				break;
			case "FriendItem":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				AddFriends (col.gameObject);
				break;
			case "coin":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioCoins, col.gameObject.transform.position, volume);
				}
				coin (col.gameObject);
				break;
			case "coin 2":
				GlobalVariables.coins = 2;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 3":
				GlobalVariables.coins = 3;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 4":
				GlobalVariables.coins = 4;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 5":
				GlobalVariables.coins = 5;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 6":
				GlobalVariables.coins = 6;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 7":
				GlobalVariables.coins = 7;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 8":
				GlobalVariables.coins = 8;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 9":
				GlobalVariables.coins = 9;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "coin 10":
				GlobalVariables.coins = 10;
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				setCoin (col.gameObject);
				break;
			case "life":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				life (col.gameObject);
				break;
			case "kill_all":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				StartCoroutine ("kill_all", col.gameObject);
				break;
			case "diamond":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				diamond (col.gameObject);
				break;
			case "invencible":
				if (sound == "on") {
					AudioSource.PlayClipAtPoint (audioItens, col.gameObject.transform.position, volume);
				}
				_GC.invencible++;
				GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
				tempPrefab.transform.position = col.gameObject.transform.position;
				Destroy (col.gameObject);
				Destroy (tempPrefab, 3);
				break;
			}
		}
	}
	public void Restart()
	{
		_GC.StartHPBar ();
		HP = HPMax;
		percLife = (HP / HPMax);

		transform.position = spawnPlayer.transform.position;
		InitialShoot ();
		playerAnimator.SetBool ("dead", false);
		GlobalVariables.Playing = true;
		_GC.StartCoroutine ("GameTime");
	}
	public void takeDamage (int damage)
	{
		if (!GlobalVariables.dead && !GlobalVariables.isInvencible) {
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
		GlobalVariables.extralifes -= 1;

//		_GC.extraLifes = GlobalVariables.extralifes;
		if (GlobalVariables.extralifes <= 0) {
			GlobalVariables.dead = true;
			playerCollider.isTrigger = true;
			playerAnimator.SetBool ("dead", true);
			playerRB.velocity = new Vector2 (0, 0);
//			playerRB.IsSleeping ();
			_GC.GameOver ();
//			Shoot = PlayerPrefs.GetString ("shoot");
		} else {
			GlobalVariables.dead = false;
			_GC.StartHPBar ();
			HP = HPMax;
			percLife = (HP / HPMax);

			transform.position = spawnPlayer.transform.position;
			InitialShoot ();
		}

	}

	//************************* Itens logics

	IEnumerator invencibleTime()
	{
		_GC.setPanel (true);
//		invenciblePanel.SetActive (true);
//		invencibleTxt.text = countdown.ToString ();
		_GC.invincibleCountDown = countdown;
		yield return new WaitForSeconds (1);
		countdown--;
		if (countdown > 0 ) {
			StartCoroutine ("invencibleTime");
		} else {
			_GC.speeddown ();
			speed = speed_ant;
//			invencibleTxt.text = "";
			GlobalVariables.isInvencible = false;
			speed = speed_ant;
			playerAnimator.SetBool ("invencible", false);
			_GC.setPanel (false);
//			invenciblePanel.SetActive (false);
//			playerAnimator.SetBool ("fly", true);
//			Vector3 theScale = new Vector3 (0.5f, 0.5f, 0.5f);
//			transform.transform.localScale = theScale;
			if (firstAlive) {
				Friend1.SetActive (true);
			}
			if (secondAlive) {

				Friend2.SetActive (true);
			}
		}

	}
	public void invencible()
	{
		switch (GlobalVariables.playerColor) {
		case "red":
			countdown = WhichTime(PlayerPrefs.GetInt ("redinvincible"));
			break;
		case "green":
			countdown = WhichTime(PlayerPrefs.GetInt ("greeninvincible"));
			break;
		case "blue":
			countdown = WhichTime(PlayerPrefs.GetInt ("blueinvincible"));
			break;
		case "yellow":
			countdown = WhichTime(PlayerPrefs.GetInt ("yellowinvincible"));
			break;
		}

		if (firstAlive) {
			Friend1.SetActive (false);
		}
		if (secondAlive) {

			Friend2.SetActive (false);
		}
		_GC.invencible--;
		GlobalVariables.invencible--;
		GlobalVariables.isInvencible = true;
		playerAnimator.SetBool ("invencible", true);
//		Vector3 theScale = new Vector3 (1, 1, 1);
//		transform.localScale = theScale;
		speed_ant = speed;
		speed *= 2;
		_GC.speedup ();


		StartCoroutine ("invencibleTime");

	}
	IEnumerator kill_all (GameObject GO)
	{
		killall = true;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
		yield return new WaitForSeconds (1.5f);
		killall = false;
	}

	void diamond (GameObject GO)
	{
		_GC.diamonds++;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);

	}
	void powerup(GameObject GO)
	{
		GlobalFunctions.achieviments ("powerup");
		powerUps++;
		GlobalVariables.points += 100 * powerUps;
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
			damageShoot4++;
			break;
		}
	}
	void setCoin(GameObject GO)
	{
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);

	}
	void coin(GameObject GO)
	{

//		total_coins = total_coins + coins;
		_GC.coins = _GC.coins + GlobalVariables.coins;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);

	}

	void life(GameObject GO)
	{
		GlobalVariables.extralifes++;
//		_GC.extraLifes = GlobalVariables.extralifes;
		GameObject tempPrefab = Instantiate (prefabParticles) as GameObject;
		tempPrefab.transform.position = GO.transform.position;
		Destroy (GO);
		Destroy (tempPrefab, 3);
	}
}
