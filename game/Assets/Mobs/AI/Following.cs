﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour {

	public Transform following;
	public float acceleration;
	public float maxSpeed;
	public float sampledPositionFrequency;
	public bool freezePositionAfterSample;

	private Rigidbody2D rb2d;
	private Vector2 sampledPosition;
	private float samplePositionTimer;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		samplePositionTimer = sampledPositionFrequency;
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
			sampledPosition = following.transform.position;
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
