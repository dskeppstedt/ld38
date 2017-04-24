using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

	public MobType mobType;
	public float life; 
	public int energy;
	private Energy playerEnergy;

	private float _life;


	// Use this for initialization
	public void Start () {
		_life = life;
		playerEnergy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Energy>();
	}

	public void Reset() {
		life = _life;
	}

	private void Die() {
		playerEnergy.IncreaseEnergy (energy);
		StartCoroutine ("deactivate");
	}
	IEnumerator deactivate() {
		yield return new WaitForEndOfFrame();
		gameObject.SetActive (false);
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.collider.tag == "Bullet") {
			life -= col.collider.GetComponent<Bullet> ().damage;
			Vector2 dir = (this.transform.position - col.transform.position).normalized;

			GetComponent<Rigidbody2D> ().AddForce (dir * 15, ForceMode2D.Impulse);

			if (life <= 0) {
				Die ();
			}
		}
	}
}
