using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
	private Player Player;
	public	int damage;
	void Start()
	{
		Player = FindObjectOfType (typeof(Player)) as Player;

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			Player.shootEnemy (damage);
		}

		if (!col.isTrigger) {
			// Se colidir com algo que nao seja um trigger
			Destroy(this.gameObject);
		}

	}
}
