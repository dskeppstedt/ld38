using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool open;
	Animator anim;
	private SpriteRenderer sr;

	void Start () {
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
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
		sr.sortingOrder = 1;
	}

	public void SetOpen(){
		open = true;
		sr.sortingOrder = -10;
	}
}