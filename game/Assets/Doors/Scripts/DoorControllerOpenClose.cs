using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerOpenClose : DoorController,Opener,Closer {

	void Update () {
		if (trigger.active && Input.GetButtonDown("Action")) {
			ActiveAllDoors ();
		}
	}

	void ActiveAllDoors() {
		foreach(Door d in doors){
			if (d.open) Close (d); else Open (d);
		}
	}

	public void Open(Door door){
		door.OpenDoor ();
		this.gameObject.GetComponentInChildren<Interactable> ().SetColor (Color.green);
	}

	public void Close(Door door){
		door.CloseDoor();
		this.gameObject.GetComponentInChildren<Interactable> ().SetColor (Color.white);
	}
}