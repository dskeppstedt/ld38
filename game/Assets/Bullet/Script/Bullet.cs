using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public bool bounce;
	public float damage;
	public float kickback;

	private Vector2 oldVelocity;

	// Use this for initialization
	void Start () {
		this.gameObject.AddComponent<BulletCollision> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		// because we want the velocity after physics, we put this in fixed update
		oldVelocity = GetComponent<Rigidbody2D>().velocity;
	}

	public Vector2 GetOldVelocity(){
		return oldVelocity;
	}
}