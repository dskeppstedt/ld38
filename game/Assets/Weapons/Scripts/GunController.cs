using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public Weapon[] weapons;

	private Weapon currentWeapon;
	private float shootTimerEnd = 0;
	private bool canShoot = true;
	private int burstLeft = 0;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWeapon != null){
			if(currentWeapon.burst <= 0){
				currentWeapon.burst = 1;
			}

			shootTimerEnd -= Time.deltaTime;

			if(!currentWeapon.automatic && Input.GetMouseButtonDown(0) && canShoot){
				burstLeft = currentWeapon.burst;
			}else if(currentWeapon.automatic && Input.GetMouseButton(0) && canShoot){
				burstLeft = currentWeapon.burst;
			}
			if(shootTimerEnd <= 0){
				canShoot = true;
			}
		}

		//cheats
		if(Input.GetKey(KeyCode.Alpha1)){
			EquipWeapon (0);
		}
		if(Input.GetKey(KeyCode.Alpha2)){
			EquipWeapon (1);
		}
		if(Input.GetKey(KeyCode.Alpha3)){
			EquipWeapon (2);
		}
		

	}

	void FixedUpdate(){
		if(burstLeft > 0){
			Fire (); 
		}
	}

	void Fire(){

		canShoot = false;
		shootTimerEnd = currentWeapon.rateOfFire;
		GetComponent<AudioSource> ().PlayOneShot (currentWeapon.sound);
		Camera.main.GetComponent<CameraFollowObject> ().Shake ();
		float angle = transform.rotation.eulerAngles.z;
		Bullet bulletClone = Instantiate(currentWeapon.bullet, transform.position,transform.rotation).GetComponent<Bullet>();
		float x = Mathf.Cos (angle * Mathf.Deg2Rad);
		float y = Mathf.Sin (angle * Mathf.Deg2Rad);

		Vector2 bulletDir = new Vector2 (x, y).normalized;
		bulletClone.GetComponent<Rigidbody2D> ().velocity = bulletDir * currentWeapon.bulletSpeed;


		float kickback = bulletClone.kickback;
		player.GetComponent<Rigidbody2D> ().AddForce (bulletDir * -kickback, ForceMode2D.Impulse);


		burstLeft--;
	}

	public void EquipWeapon(int index){
		currentWeapon = weapons [index];
		player.GetComponent<SpriteRenderer> ().sprite = currentWeapon.sprite;
	}
}
