using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : DoorController {

	public GameObject goal;

	// Use this for initialization
	void Start () {
		base.Start ();
		goal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger.active && Input.GetButtonDown("Action") && !goal.activeSelf) {
			goal.SetActive (true);
		}
	}
}
