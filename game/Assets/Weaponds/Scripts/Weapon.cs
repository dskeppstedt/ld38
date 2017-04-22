using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float rateOfFire; 
	public float bulletSpeed;
	public bool automatic;
	public int burst;
	public GameObject bullet;
	public AudioClip sound;

	private float shootTimerEnd = 0;
	private bool canShoot = true;
	private int burstLeft = 0;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if(burst <= 0){
			burst = 1;
		}

		shootTimerEnd -= Time.deltaTime;

		if(!automatic && Input.GetMouseButtonDown(0) && canShoot){
			burstLeft = burst;
		}else if(automatic && Input.GetMouseButton(0) && canShoot){
			burstLeft = burst;
		}
		if(shootTimerEnd <= 0){
			canShoot = true;
		}
	}

	void FixedUpdate(){
		if(burstLeft > 0){
			Fire (); 
		}
	}

	void Fire(){

		canShoot = false;
		shootTimerEnd = rateOfFire;
		GetComponent<AudioSource> ().PlayOneShot (sound);
		Camera.main.GetComponent<CameraFollowObject> ().Shake ();
		float angle = transform.rotation.eulerAngles.z;
		Bullet bulletClone = Instantiate(bullet, transform.position,transform.rotation).GetComponent<Bullet>();
		float x = Mathf.Cos (angle * Mathf.Deg2Rad);
		float y = Mathf.Sin (angle * Mathf.Deg2Rad);


		bulletClone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (x,y).normalized * bulletSpeed;

		burstLeft--;
	}
}
