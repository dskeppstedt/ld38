﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Disable");
		this.gameObject.SetActive (false);
	}
}