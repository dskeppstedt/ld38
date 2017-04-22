using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnEnable : MonoBehaviour {

	public AudioClip soundToPlay;

	void OnEnable(){
		GetComponent<AudioSource> ().PlayOneShot (soundToPlay);
	}
}
