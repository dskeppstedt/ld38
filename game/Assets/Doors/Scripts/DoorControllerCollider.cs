using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DoorControllerCollider:MonoBehaviour{

	[HideInInspector]
	public bool active = false;

	void OnTriggerEnter2D(Collider2D other) {
		active = other.tag == "Player";
	}

	void OnTriggerExit2D(Collider2D other) {
		active = !(other.tag == "Player");
	}
}