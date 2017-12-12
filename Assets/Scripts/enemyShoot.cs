using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {
	public	int damage;
	void Start()
	{

	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" ) {
//			Player.shootEnemy (damage);
			col.gameObject.SendMessage("shootEnemy",damage);
//			Player.takeDamage(damage);

		}

		if (!col.isTrigger) {
			// Se colidir com algo que nao seja um trigger
			Destroy(this.gameObject);
		}


	}
}
