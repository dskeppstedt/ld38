using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public float damage;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<BulletCollision> ();
		this.gameObject.AddComponent<Explosion> ();
		Debug.Log ("Hello");

	}
	
	// Update is called once per frame
	void Update () {
		//TODO DESTORY 
	}
}