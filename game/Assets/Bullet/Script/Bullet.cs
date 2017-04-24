using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float damage;
	public float kickback;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<BulletCollision> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}