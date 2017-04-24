using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour {

	public GameObject explosion;

	void OnCollisionEnter2D (Collision2D col){
		GameObject exp = Instantiate (explosion);
		exp.transform.position = this.transform.position;
	}
}
