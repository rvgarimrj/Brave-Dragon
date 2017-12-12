using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour {
	public	float	speed,speed_ant;
	private	float	offset;
	private	Material	currentMaterial;

	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer> ().material;
		speed_ant = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += speed * 0.001f;
		currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
	public void speedup(float speed_actual)
	{
		
  		speed = speed + speed_actual;
	}
	public void speeddown(float speed_actual)
	{
		speed = speed - speed_actual;
	}
}
