using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

	public Transform following;
	public float acceleration;
	public float maxSpeed;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		Vector2 direction = (following.position - transform.position).normalized;
		rb2d.AddForce (direction * acceleration);
		rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed); 
	}
}
