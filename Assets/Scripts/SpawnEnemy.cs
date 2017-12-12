using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
	public	GameObject[]	prefabEnemy;
	public	float 		spawnTimer;
	public	Transform	TopLimit, BottomLimit;
	private int	maxLenght;
	private	float tempTime,minY, maxY;

	// Use this for initialization
	void Start () {
		minY = BottomLimit.position.y;
		maxY = TopLimit.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempTime += Time.fixedDeltaTime;
		if (tempTime >= spawnTimer) 
		{
			tempTime = 0;
			if (!GlobalVariables.paused && !GlobalVariables.dead)  {
				Spawn ();
			}
		}
	}

	void Spawn()
	{
		
		maxLenght = prefabEnemy.Length;
		int rand = Random.Range (0, maxLenght);
		GameObject tempPrefab = Instantiate (prefabEnemy[rand]) as GameObject;
		float	posY = Random.Range (minY, maxY);
		tempPrefab.transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
			
	}
}
