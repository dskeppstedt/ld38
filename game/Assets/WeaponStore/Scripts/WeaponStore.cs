using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : MonoBehaviour {

	public GameObject[] weaponItems;


	// Use this for initialization
	void Start () {
		int offset = 0;
		foreach (GameObject ob in weaponItems) {
			

			GameObject gun = Instantiate (ob,this.transform);
			gun.transform.Translate (offset, 0, 0);
			offset++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
