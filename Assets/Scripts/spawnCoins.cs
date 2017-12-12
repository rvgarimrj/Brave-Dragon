using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCoins : MonoBehaviour {
	public	GameObject[]	prefabEnemy;
	public	float 		spawnTimer;
	public	Transform	TopLimit, BottomLimit;
	private	float tempTime,minY, maxY;
	private GameObject tempPrefab;
	private int index;
	[SerializeField] private float percSpawnCoins;

	// Use this for initialization
	void Start () {
		minY = BottomLimit.position.y;
		maxY = TopLimit.position.y;

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!GlobalVariables.paused && !GlobalVariables.dead) { 
			tempTime += Time.fixedDeltaTime;
			if (tempTime >= spawnTimer) {
				tempTime = 0;
				int rand;
				rand = Random.Range (0, 99);
				if (rand <= percSpawnCoins && GlobalVariables.coins < 10) {
					Spawn ();
				}
			}
		}
	}

	void Spawn()
	{
		if (GlobalVariables.coins == 1) {
			tempPrefab = Instantiate (prefabEnemy [0]) as GameObject;
		}
		if (GlobalVariables.coins > 1 && GlobalVariables.coins < 10) {
			tempPrefab = Instantiate (prefabEnemy [GlobalVariables.coins -1]) as GameObject;
		}
		float	posY = Random.Range (minY, maxY);
		tempPrefab.transform.position = new Vector3 (transform.position.x, posY, transform.position.z);
	}
}
