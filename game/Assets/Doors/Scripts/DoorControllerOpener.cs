using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerOpener : DoorController, Opener {

	void Update () {
		if (trigger.active && Input.GetButtonDown("Action")) {
			OpenAllDoors ();
		}
	}
		
	void OpenAllDoors() {
		foreach(Door d in doors){
			Open (d);
		}
	}

	public void Open(Door door){
		door.OpenDoor ();
		this.gameObject.GetComponentInChildren<Interactable> ().SetColor (Color.green);
	}
}
