using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveItens : MonoBehaviour {
	private Rigidbody2D	itemRB;
	public	float speed;


	// Use this for initialization
	void Start () {
		itemRB = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		itemRB.velocity = new Vector2 (-1 * speed,  0);
	}
	void setSpeed(float speedInherited)
	{
		speed = speedInherited;
	}
}
