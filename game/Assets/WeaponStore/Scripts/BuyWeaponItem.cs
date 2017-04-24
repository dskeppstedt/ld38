using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeaponItem : MonoBehaviour {

	private bool insideCollider;
	private GameObject player;

	public void Start() {
		player = GameObject.FindWithTag ("Player");

	}


	void Update() { 

		if (insideCollider) {
			if (Input.GetButtonUp ("Action")) {
				int price = GetComponentInParent<WeaponItemDetail> ().price;
				int weaponId = GetComponentInParent<WeaponItemDetail> ().id;
				player.GetComponent<Energy> ().ReduceEnergy (price);
				player.GetComponentInChildren<GunController> ().EquipWeapon (weaponId);
			}
		}		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			insideCollider = true;
		}	

	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			insideCollider = false;
		}
	}
}