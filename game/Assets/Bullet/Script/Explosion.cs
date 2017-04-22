using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D other) {
		GameObject exp = Instantiate (explosion);
		exp.transform.position = this.transform.position;
	}
}
