﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
	
	void OnCollisionEnter2D (Collision2D col){
		this.gameObject.SetActive (false);
	}
}