using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

	// Use this for initialization
	void Start () {
		GetComponent<Following> ().following = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
