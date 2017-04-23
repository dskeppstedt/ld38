using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class Attack : MonoBehaviour {

	public int damage;
	private float force;
	public float cooldown;
	private float attackTimer;
	private bool inRange;
	private GameObject player;
	private Rigidbody2D playerRb;
	private Energy playerEnergy;

	public void Start() {

		player = GameObject.FindGameObjectWithTag ("Player");
		playerRb = player.GetComponent<Rigidbody2D> ();
		playerEnergy = player.GetComponent<Energy> ();

		force = damage * 0.5f;
		force = Mathf.Clamp (force, 1, 15);

		attackTimer = cooldown;
	}

	private void attackClock() {
		if (canStrike()) {
			if (inRange) {
				attackPlayer ();
				attackTimer = cooldown; //reset the counter
			}
		}
	}

	public void FixedUpdate() {
		attackClock ();
	}

	public void attackPlayer(){
		//force
		Vector2 attack_direction = (player.transform.position - this.transform.position).normalized;
		playerRb.AddForce (attack_direction * force,ForceMode2D.Impulse);
		GetComponent<Rigidbody2D> ().AddForce (attack_direction * -force,ForceMode2D.Impulse);

		//energy
		playerEnergy.ReduceEnergy(damage);


		Debug.Log ("Attack");
	}
		
	bool canStrike() {
		if (attackTimer > 0) {
			attackTimer -= Time.deltaTime;
			return false;
		}
		return true;
	}

	bool canAttack() {
		return true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "PlayerDamage") {
			Debug.Log ("In range");
			inRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "PlayerDamage") {
			Debug.Log ("Out of range");
			inRange = false;
		}
	}
}