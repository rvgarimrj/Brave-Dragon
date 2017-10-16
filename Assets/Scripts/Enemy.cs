using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

//	private	Player Player;
	private Rigidbody2D		enemyRB;
	private	int				XMove,YMove,rand;
	private	float			tempTime,tempTimeShoot;
	public	float			speed, shootForce,timeForChangeSide,timeForShooting;
	public	Transform		enemyShoot;
	public	GameObject 		prefabShoot,prefabExplosion;
	public	int				percentualOfChangeSide,percentualOfShooting,HP;
	public	GameObject 		gotHit;


	// Use this for initialization
	void Start () {

		enemyRB = GetComponent<Rigidbody2D> ();
		XMove = -1;
//		Player = FindObjectOfType (typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempTime += Time.fixedDeltaTime;
		tempTimeShoot += Time.fixedDeltaTime;

		if (tempTime >= timeForChangeSide) {
			tempTime = 0;
			rand = Random.Range (0, 100);
			if (rand <= percentualOfChangeSide) {
				rand = Random.Range (0, 100);
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
			rand = Random.Range (0, 100);
			if (rand <= percentualOfShooting) {
				fire ();
			}
		}
		enemyRB.velocity = new Vector2 (XMove * speed, YMove * speed);
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
		case "playerShoot":
			takeDamage (1);
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		switch (col.gameObject.tag) 
		{
		case "Player":
			explode ();
			break;
		} 
	}


	void takeDamage (int damage)
	{
		HP -= damage;
		StartCoroutine("blink");
		if (HP <= 0) {
			explode ();

		}
	}

	void explode()
	{
		GameObject tempPrefab = Instantiate (prefabExplosion) as GameObject;
		tempPrefab.transform.position = transform.position;
		tempPrefab.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMove * speed, 0);
		Destroy (this.gameObject);
	}

	IEnumerator	blink()
	{
		gotHit.SetActive (true);
		yield return new WaitForSeconds(0.5f);
		gotHit.SetActive (false);
			
	}
}
