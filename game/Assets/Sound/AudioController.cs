using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

	public AudioMixer main;
	public AudioMixerSnapshot soundOn, soundOff, soundInit;
	private bool muted;

	void Start(){
		muted = false;
	}

	void Update () {
		HandleInput ();	
	}

	void HandleInput(){
		if (Input.GetKeyDown (KeyCode.M)) {
			if (muted) {
				soundOn.TransitionTo (1f);
				muted = false;
			} else {
				soundOff.TransitionTo (1f);
				muted = true;
			}
		}
	}
}
