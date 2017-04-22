using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour {

	public GameObject weapon;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		Vector2 dir = GetComponent<MovementController> ().getDir ();
	

		weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y,dir.x)));

	}
}

