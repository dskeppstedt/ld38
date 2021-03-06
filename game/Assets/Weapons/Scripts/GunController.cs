﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public Weapon[] weapons;

	private Weapon currentWeapon;
	private float shootTimerEnd = 0;
	private bool canShoot = true;
	private int burstLeft = 0;
	private AudioSource audioSrc;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		audioSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWeapon != null){
			if(currentWeapon.burst <= 0){
				currentWeapon.burst = 1;
			}

			shootTimerEnd -= Time.deltaTime;

			if (!currentWeapon.automatic && Input.GetMouseButtonDown (0) && canShoot) {
				burstLeft = currentWeapon.burst;
			} else if (currentWeapon.automatic && Input.GetMouseButton (0) && canShoot) {
				if (!audioSrc.isPlaying) {
					FireSFX ();
				}
				burstLeft = currentWeapon.burst;
			}
			if (currentWeapon.automatic && currentWeapon.burst < 2 && Input.GetMouseButtonUp (0)) {
				if (audioSrc.isPlaying) {
					audioSrc.Stop ();
				}
			}
			if(shootTimerEnd <= 0){
				canShoot = true;
			}
		}

		//cheats

	}

	void FixedUpdate(){
		if(burstLeft > 0){
			Fire (); 
		}
	}

	void Fire(){
		Camera.main.GetComponent<CameraFollowObject> ().Shake ();
		FireSFX ();

		canShoot = false;
		shootTimerEnd = currentWeapon.rateOfFire;
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

	void FireSFX(){
		// Superhaxx to handle voice-stealing
		if (currentWeapon.sound == audioSrc.clip) {
			if (currentWeapon.burst > 1 && burstLeft < currentWeapon.burst) {
				return;
			}
			if (currentWeapon.automatic && audioSrc.isPlaying) {
				return;
			}
		}
		audioSrc.Stop ();
		audioSrc.clip = currentWeapon.sound;
		audioSrc.loop = currentWeapon.automatic && currentWeapon.burst < 2;
		audioSrc.time = 0f;
		audioSrc.Play ();
	}
}
