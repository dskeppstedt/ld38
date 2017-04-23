using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoorController : MonoBehaviour{
	public Door[] doors;
	protected DoorControllerCollider trigger;

	void Start () {
		trigger = GetComponent<DoorControllerCollider> ();
	}
}
