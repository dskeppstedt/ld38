using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZoneController : MonoBehaviour {

	DoorControllerCollider zone;
	Door door;
	public bool canOpen = true;

	void Start () {
		door = GetComponentInParent<Door> ();
		zone = GetComponent<DoorControllerCollider> ();

	}

	void Update () {
		if (zone.active && canOpen) {
			canOpen = false;
			door.OpenDoor ();
		}

		if (!zone.active && door.open) {
			door.CloseDoor ();
		}

		if (!door.open) {
			canOpen = true;
		}

	}
}
