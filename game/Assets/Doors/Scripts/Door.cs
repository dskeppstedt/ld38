using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool open;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		
	}

	public void OpenDoor() {
		if (open) return;
		anim.SetBool ("close", false);
		anim.SetBool ("open", true);
	}

	public void CloseDoor() {
		if (!open) return;
		anim.SetBool ("open", false);
		anim.SetBool ("close", true);		
	}

	public void SetClose(){
		open = false;
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
	}

	public void SetOpen(){
		open = true;
		GetComponent<SpriteRenderer> ().sortingOrder = -10;
	}
}