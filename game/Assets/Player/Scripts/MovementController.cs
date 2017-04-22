using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float acceleration;
	public float maxSpeed;

	private Rigidbody2D rb2d;
	private float moveHorizontal;
	private float moveVertical;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
	}

	void FixedUpdate(){
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical).normalized;
		rb2d.AddForce (movement * acceleration);
		rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed);
	}

	private void HandleInput (){
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");
	}

}
