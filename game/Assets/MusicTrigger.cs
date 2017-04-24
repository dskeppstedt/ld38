using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicTrigger : MonoBehaviour {

	public AudioSource src;
	public AudioMixerSnapshot music;
	public float fadeInTime;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			PlayMusic ();
			gameObject.SetActive(false);
		}
	}

	void PlayMusic(){
		src.Play ();
		music.TransitionTo (fadeInTime);
	}
}
