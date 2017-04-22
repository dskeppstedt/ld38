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
		Vector3 mousePos3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePos = new Vector2 (mousePos3.x, mousePos3.y);
		Vector2 dir = (mousePos - new Vector2(transform.position.x,transform.position.y)).normalized;
	

		weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y,dir.x)));
	}
}

