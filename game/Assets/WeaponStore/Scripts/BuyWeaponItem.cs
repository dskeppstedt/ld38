using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponItem : MonoBehaviour {

	private bool insideCollider;

	void Update() { 

		if (insideCollider) {
			//Can buy item lol..

			if (Input.GetButtonUp ("Action")) {
				Debug.Log("Buygin for $ " + GetComponentInParent<WeaponItemDetail>().price);
			}



		}		

	}


	void OnTriggerEnter2D(Collider2D other) {
		insideCollider = other.tag == "Player";
	}

	void OnTriggerExit2D(Collider2D other) {
		insideCollider = !(other.tag == "Player");
	}
		
}
