﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

	// Use this for initialization
	public void Start () {
		base.Start();
		GetComponent<Following> ().following = GameObject.FindGameObjectWithTag ("Player");
	}


	// Update is called once per frame
	void Update () {
		if (life < 0) {
			GetComponent<SplatterSpawner> ().SpawnSplatter ();
		}


	}
}
