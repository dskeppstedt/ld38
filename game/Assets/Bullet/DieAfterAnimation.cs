using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterAnimation : MonoBehaviour {

	public void Die() {
		var audioSource = GetComponent<AudioSource> ();
		if (audioSource != null && GetComponent<AudioSource> ().isPlaying) {
			Invoke("Die", 1f);
		} else {
			Destroy (this.gameObject);
		}
	}
}
