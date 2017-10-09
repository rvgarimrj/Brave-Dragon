using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	public	GameObject	prefabEnemy;
	public	float 		spawnTimer;
	public	Transform	TopLimit, BottomLimit;

	private	float tempTime,minY, maxY;

	// Use this for initialization
	void Start () {
	
		minY = BottomLimit.position.y;
		maxY = TopLimit.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		tempTime += Time.fixedDeltaTime;
		if (tempTime >= spawnTimer) 
		{
			tempTime = 0;
			Spawn ();
		}
	}

	void Spawn()
	{
		GameObject tempPrefab = Instantiate (prefabEnemy) as GameObject;
		float	posY = Random.Range (minY, maxY);
		tempPrefab.transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
			
	}
}
