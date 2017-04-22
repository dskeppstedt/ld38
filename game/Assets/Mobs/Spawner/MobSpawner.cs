using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public Enemy[] enemyTypes;
	public float enemySpawnTime;
	public bool randomizeTime;
	public int poolSize;

	private float enemySpawnTimer;

	// Pools
	private Dictionary<MobType, Enemy[]> enemyPools;
	private GameObject pools;

	// Use this for initialization
	void Start () {
		enemySpawnTimer = enemySpawnTime;
		pools = new GameObject ();
		pools.transform.parent = this.transform;
		enemyPools = new Dictionary<MobType, Enemy[]> ();
	}
	
	// Update is called once per frame
	void Update () {
		enemySpawnTimer -= Time.deltaTime;
		if (enemySpawnTimer < 0) {
			SpawnEnemy (enemyTypes[Random.Range(0, enemyTypes.Length)].mobType);
		}
	}

	void SpawnEnemy(MobType m){
		Transform t = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Enemy e = GetEnemy (m);
		e.transform.position = t.position;
		e.gameObject.SetActive (true);
	}

	Enemy GetEnemy(MobType m){
		Enemy[] pool = enemyPools [m];
		foreach (Enemy e in pool) {
			if (!e.gameObject.activeInHierarchy) {
				return e;
			}
		}
		Debug.Log ("Buffer overrun in pool " + m);
		return pool [Random.Range (0, pool.Length)];
	}

	void InitPools(){
		foreach (Enemy e in enemyTypes) {
			MobType m = e.mobType;
			GameObject poolParentObject = new GameObject (e.mobType.ToString());
			poolParentObject.transform.parent = this.transform;
			Enemy[] pool = new Enemy[poolSize];
			for(int i = 0; i < poolSize; i++){
				pool [i] = Instantiate (e, poolParentObject.transform);
				pool [i].gameObject.SetActive (false);
			}
			enemyPools.Add (m, pool);
		}
	}
}
