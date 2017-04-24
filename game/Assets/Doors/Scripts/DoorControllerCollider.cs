using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DoorControllerCollider:MonoBehaviour{

	//[HideInInspector]
	public bool active = false;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			active = true;	
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			active = false;
		}
	}
}