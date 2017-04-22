using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float acceleration;
	public float maxSpeed;

	private Rigidbody2D rigitbody;

	// Use this for initialization
	void Start () {
		rigitbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		HandleInput ();
		ControllMaxSpeed ();
	
	}
		
	private void HandleInput (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movment = new Vector2 (moveHorizontal, moveVertical).normalized;

		if (movment.magnitude == 0) {
			rigitbody.velocity = new Vector2 (0, 0);
		}

		rigitbody.AddForce (movment * acceleration);
	}

	private void ControllMaxSpeed(){
		if (rigitbody.velocity.magnitude > maxSpeed) {
			rigitbody.velocity = rigitbody.velocity.normalized * maxSpeed;
		}
	}
}
