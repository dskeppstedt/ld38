using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorZoneController : MonoBehaviour {

	public DoorControllerCollider zone;
	public Sprite openSprite;
	public Sprite closeSprite; 
	bool open = true;

	GameObject closedCollider;
	GameObject openCollider;

	void Start () {
		closedCollider = this.transform.FindChild ("ClosedCollider").gameObject;
		openCollider = this.transform.FindChild ("OpenCollider").gameObject;
	}

	void Update () {
		if (zone.active && !open) {
			open = true;
		}

		if (!zone.active && open) {
			open = false;

		}

		if (open) {
			GetComponent<SpriteRenderer> ().sprite = openSprite;
			closedCollider.SetActive (false);
			openCollider.SetActive (true);

		} else {
			GetComponent<SpriteRenderer> ().sprite = closeSprite;
			closedCollider.SetActive (true);
			openCollider.SetActive (false);
		}
	}
}
