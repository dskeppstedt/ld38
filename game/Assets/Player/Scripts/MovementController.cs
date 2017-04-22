using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float acceleration;
	public float maxSpeed;
	public Sprite[] bodySprites;

	private Rigidbody2D rb2d;
	private float moveHorizontal;
	private float moveVertical;
	private Vector2 dir;



	// Use this for initialization
	void Start () {
		UpdateDir ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDir ();
		HandleInput ();
		HandleSprite ();

	}

	void HandleSprite(){

		float deg = Mathf.Rad2Deg * Mathf.Atan2 (dir.y, dir.x);

		if (deg < 180 && deg > 0) {
			GetComponent<SpriteRenderer> ().sprite = bodySprites [1];
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, deg));
		} else {
			GetComponent<SpriteRenderer> ().sprite = bodySprites [0];
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, deg));
		}
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

	private void UpdateDir (){
		Vector3 mousePos3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos = new Vector2 (mousePos3.x, mousePos3.y);
		dir = (mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
	}

	public Vector2 getDir(){
		return dir;
	}

}
