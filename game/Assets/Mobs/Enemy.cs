using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

	public MobType mobType;
	public float life; 
	public float damage = 1;
	public int energy;
	private Energy playerEnergy;


	// Use this for initialization
	public void Start () {
		playerEnergy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Energy>();
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter2D (Collision2D col){
		if (col.collider.tag == "Bullet") {
			life -= col.collider.GetComponent<Bullet> ().damage;

			if (life <= 0) {
				gameObject.SetActive (false);
				playerEnergy.IncreaseEnergy (energy);
			}
		}
	}
}
