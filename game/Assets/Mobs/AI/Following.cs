using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

	public GameObject following;
	public float acceleration;
	public float maxSpeed;
	public float sampledPositionFrequency;
	public float samplePositionOvershoot;
	public bool freezePositionAfterSample;

	private Rigidbody2D rb2d;
	private Vector2 sampledPosition;
	private float samplePositionTimer;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		samplePositionTimer = sampledPositionFrequency;
	}

	void OnEnable(){
		samplePositionTimer = 0f;
	}

	void Update () {
		samplePositionTimer -= Time.deltaTime;
	}

	void FixedUpdate(){
		SampleTargetPosition ();
		PushTowardsTarget ();
	}

	void SampleTargetPosition(){
		if (samplePositionTimer < 0) {
			var overshoot = following.GetComponent<Rigidbody2D>().velocity * (1f+samplePositionOvershoot);
			sampledPosition = (Vector2)following.transform.position + overshoot;
			if (freezePositionAfterSample) {
				rb2d.velocity = Vector2.zero;
			}
			samplePositionTimer = sampledPositionFrequency;
		}
	}

	void PushTowardsTarget(){
		Vector2 direction = (sampledPosition - (Vector2)transform.position).normalized;
		rb2d.AddForce (direction * acceleration);
		rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed); 
	}
}
