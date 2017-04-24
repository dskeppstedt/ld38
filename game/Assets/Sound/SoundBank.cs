using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour {

	const int MAX_VOICES = 5;

	public AudioSource explSource;
	private static AudioSource staticExplSource;
	private static AudioSource[] explSourceBuffer;

	void Start(){
		staticExplSource = explSource;
		InitBuffers ();
	}

	void InitBuffers(){
		explSourceBuffer = new AudioSource[MAX_VOICES];
		for (int i = 0; i < MAX_VOICES; i++) {
			explSourceBuffer [i] = (Instantiate (explSource, this.transform)).GetComponent<AudioSource>();
		}
	}

	static AudioSource FindFreeSource(SoundType sound){
		switch (sound) {
		case SoundType.Explosion:
			for (int i = 0; i < explSourceBuffer.Length; i++) {
				if (!explSourceBuffer [i].isPlaying) {
					return explSourceBuffer [i];
				}
			}
			return explSourceBuffer [Random.Range (0, explSourceBuffer.Length)];
		default:
			return null;
		}
	}

	public static void PlayExplosion(Vector2 pos){
		staticExplSource = FindFreeSource (SoundType.Explosion);
		staticExplSource.transform.position = pos;
		staticExplSource.time = 0f;
		staticExplSource.Play ();
	}

	public static void PlaySound(SoundType sound, Vector2 pos){
		switch (sound) {
		case SoundType.Explosion:
			PlayExplosion (pos);
			break;
		default:
			break;
		}
	}
}

public enum SoundType { Explosion }