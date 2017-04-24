using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBankedSoundOnEnable : MonoBehaviour {

	public SoundType sound;

	void OnEnable(){
		SoundBank.PlaySound (sound, transform.position);
	}
}
