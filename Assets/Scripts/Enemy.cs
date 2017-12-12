using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private	_GC _GC;
	private	Player Player;
	private Rigidbody2D		enemyRB;
	private	int				XMove,YMove,rand,damageShoot1,damageShoot2,damageShoot3,damageShoot4;
	private	float			tempTime,tempTimeShoot;
	public	float			speed, shootForce,timeForChangeSide,timeForShooting;
	public	Transform		enemyShoot;
	public	GameObject 		prefabShoot,prefabExplosion;
	public	int				percentualOfChangeSide,percentualOfShooting,HP,totalScore,lootPercentage;
	public	GameObject 		gotHit;
	public	int 			damage;
	public	GameObject[] 	loot;
	private	GameObject[]    loot_array;
	// Use this for initialization
	void Start () {
		_GC = FindObjectOfType (typeof(_GC)) as _GC;
		Player = FindObjectOfType (typeof(Player)) as Player;


		//		HP = HP + _GC.HP;

		// *******************************************************************
		// Get initial values from Game Controller based on Game Time Played

		speed =  GlobalVariables.enemySpeed;

		if ((timeForShooting - GlobalVariables.timeForShooting) <= 0) {
			timeForShooting = 0;
		} else {
			timeForShooting = timeForShooting - GlobalVariables.timeForShooting;
		}
		if ((timeForChangeSide - GlobalVariables.timeForChangeSide) <= 0) {
			timeForChangeSide = 0;
		} else {
			timeForChangeSide -= GlobalVariables.timeForChangeSide;
		}
		shootForce -= GlobalVariables.shootForce;
//		print (shootForce);
		if ((percentualOfChangeSide + GlobalVariables.percentualOfChangeSide) >= 100) {
			percentualOfChangeSide = 100;
		} else {
			percentualOfChangeSide += GlobalVariables.percentualOfChangeSide;
		}
		if ((percentualOfShooting + GlobalVariables.percentualOfShooting) >= 100) {
			percentualOfShooting = 100;
		} else {
			percentualOfShooting += GlobalVariables.percentualOfShooting;
		}

		// *******************************************************************

//		if (GlobalVariables.enemySpeed > 0) {
//			
//			print ("Time For Shooting" + timeForShooting.ToString ());
//			print ("Time For Change Side" + timeForChangeSide.ToString ());
//			print ("Percentual of change side" + percentualOfChangeSide.ToString ());
//			print ("Percentual of shooting" + percentualOfShooting.ToString ());
//		}
		damageShoot1 = Player.damageShoot1;
		damageShoot2 = Player.damageShoot2;
		damageShoot3 = Player.damageShoot3;
		damageShoot4 = Player.damageShoot4;

		enemyRB = GetComponent<Rigidbody2D> ();
		XMove = -1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GlobalVariables.paused && !GlobalVariables.dead) {
			tempTime += Time.fixedDeltaTime;
			tempTimeShoot += Time.fixedDeltaTime;

			if (tempTime >= timeForChangeSide) {
				tempTime = 0;
				rand = Random.Range (0, 99);
				if (rand <= percentualOfChangeSide) {
					rand = Random.Range (0, 99);
					{
						if (rand < 50) {
							// Move Up
							YMove = 1;
						} else {
							YMove = -1;
						}
					}
				} else {
					YMove = 0;
				}
			}

			if (tempTimeShoot >= timeForShooting) {
				tempTimeShoot = 0;
				rand = Random.Range (0, 99);
				if (rand <= percentualOfShooting) {
					fire ();
				}
			}
			enemyRB.velocity = new Vector2 (XMove * speed, YMove * speed);
			if (Player.killall) {
				killall ();
			}
		} else {
			enemyRB.velocity = new Vector2 (0,0);
		}
	}

	void fire()
	{
		GameObject tempPrefab = Instantiate (prefabShoot) as GameObject;
		tempPrefab.transform.position = enemyShoot.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));

	}

	void OnTriggerEnter2D(Collider2D col)
	{
			switch (col.tag) {
			case "playerShoot1":
				takeDamage (damageShoot1);
				break;
			case "playerShoot2":
				takeDamage (damageShoot2);
				break;
			case "playerShoot3":
				takeDamage (damageShoot3);
				break;
			case "playerShoot4":
				takeDamage (damageShoot4);
				break;
			case "Friend1":
				GlobalVariables.actualPlayer.SendMessage("FriendDestroyed", "Friend1");
				explode ();
				break;
			case "Friend2":
				GlobalVariables.actualPlayer.SendMessage("FriendDestroyed", "Friend2");
				explode ();
				break;
			case "Player":
				explode ();
				break;

		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

			switch (col.gameObject.tag) {
			case "Player":
				explode ();
				break;
		}
	}


	void takeDamage (int damage)
	{
			
			HP -= damage;
			StartCoroutine ("blink");
			if (HP <= 0) {
				die ();

		}
	}
	void lootSpawn()
	{
		rand = Random.Range (0, 99);
		if (rand <= lootPercentage) {
			int length = loot.Length;
			if (length == 1) { // Is a common item
				GameObject tempLoot = Instantiate (loot [0]) as GameObject;
				tempLoot.SendMessage ("setSpeed", speed, SendMessageOptions.DontRequireReceiver);
				tempLoot.transform.position = transform.position;
				if (loot [0].tag == "coin") {
 					rand = Random.Range (1, 4);
					loot_array = new GameObject[rand];
					for (int i = 0; i <= rand - 1 ; i++) {
						loot_array [i] = Instantiate (loot[0]) as GameObject;
						loot_array [i].SendMessage ("setSpeed", speed, SendMessageOptions.DontRequireReceiver);
						loot_array [i].transform.position = new Vector3 (transform.position.x + ((i + 1) * 0.8f), transform.position.y, transform.position.z);
					}
				}
			} else if (length > 1)// Item is red,green,blue,yellow
			{
				int index;
				index = Random.Range (0, 3);
				GameObject tempLoot = Instantiate (loot [index]) as GameObject;
				tempLoot.SendMessage ("setSpeed", speed, SendMessageOptions.DontRequireReceiver);
				tempLoot.transform.position = transform.position;
				tempLoot.name = loot [index].name;
			}
		}
	}
	void killall()
	{
		GlobalFunctions.achieviments ("enemy");
		GameObject tempPrefab = Instantiate (prefabExplosion) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMove * speed, 0);
		GlobalVariables.points += totalScore;
//		if(_GC.points > PlayerPrefs.GetInt("points"))
//		{
//			PlayerPrefs.SetInt ("points", _GC.points);
//		}
		lootSpawn ();		
		Destroy (this.gameObject);

	}
	void die()
	{
		GlobalFunctions.achieviments ("enemy");
		GameObject tempPrefab = Instantiate (prefabExplosion) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMove * speed, 0);
		GlobalVariables.points += totalScore;
//		if(_GC.points > PlayerPrefs.GetInt("points"))
//		{
//			PlayerPrefs.SetInt ("points", _GC.points);
//		}
		lootSpawn ();
		Destroy (this.gameObject);
	}
	void explode()
	{
			
		if (!GlobalVariables.isInvencible && !GlobalVariables.dead) {
			GlobalFunctions.achieviments ("enemy");
			GlobalVariables.actualPlayer.SendMessage("takeDamage",damage);
			}
			GameObject tempPrefab = Instantiate (prefabExplosion) as GameObject;
			tempPrefab.transform.position = transform.position;
			tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMove * speed, 0);
			GlobalVariables.points += totalScore;
//			if (_GC.points > PlayerPrefs.GetInt ("points")) {
//				PlayerPrefs.SetInt ("points", _GC.points);
//			}
			lootSpawn ();
			Destroy (this.gameObject);
		}


	IEnumerator	blink()
	{
		gotHit.SetActive (true);
		yield return new WaitForSeconds(0.5f);
		gotHit.SetActive (false);
			
	}
}
