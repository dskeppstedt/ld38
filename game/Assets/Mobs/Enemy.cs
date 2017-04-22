using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

	public MobType mobType;
	public float life; 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter2D (Collision2D col){
		if (col.collider.tag == "Bullet") {
			life -= col.collider.GetComponent<Bullet> ().damage;

			if (life <= 0) {
				gameObject.SetActive (false);
			}
		}
	}
}
