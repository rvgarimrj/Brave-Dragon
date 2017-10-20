using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFriend : MonoBehaviour {

	private	Player	Player;
//	private	Animator		playerAnimator;
	private	string[] 		shoot;
	public int 			index;
	public	float			shootForce;
	public  Transform 		playerShoot;
	public	GameObject[] 	prefabShoot;


	// Use this for initialization
	void Start () {
		Player = FindObjectOfType(typeof(Player)) as Player;

		shootForce = Player.shootForce;

//		playerAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		} 

	public void Fire()
	{	index = Player.index;
//		float x = (float) (index / 10);
//		print ((float)(x));
		GameObject tempPrefab = Instantiate (prefabShoot[index]) as GameObject;
		tempPrefab.transform.position = playerShoot.position;
		Vector3 theScale = new Vector3 (0.4f, 0.4f, 0.4f);
		print (theScale);
		tempPrefab.transform.localScale = theScale;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (shootForce, 0));
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		switch (col.gameObject.tag) {
			case "Enemy":
				Player.FriendDestroyed (this.tag);
				Destroy (this.gameObject);
				break;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{	
		switch (col.gameObject.tag) 
		{
			case "enemyShoot":
				Player.FriendDestroyed (this.tag);
				Destroy (this.gameObject);
				break;


		}
	}

}
