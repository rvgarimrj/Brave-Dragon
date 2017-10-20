using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayerTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy" ) {
			// Se colidir com algo que nao seja um trigger
			Destroy(this.gameObject);
		}
	}
}
