using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class StoryText : MonoBehaviour {
	
	public Text textfield;
	public float timeForChar;

	AudioSource audioPlayer;

	string story = "Nucelar war destroyed earth!\nYou have been awoken from cryosleep. Your mission is to get to the moon and help with the repopulation of the new small world.\nThere is only one problem, the path between the cryo room and the rocket launch pad has been breached and all kinds of horrors wander these halls. Stay safe and save humanity!";

	// Use this for initialization
	void Start () {

		audioPlayer = GetComponent<AudioSource> ();
		textfield.text = "";
		StartCoroutine ("UpdateText");
	
	}

	void Done() {
		GetComponent<DisableEnableOnPress> ().onPress ();
	}

	IEnumerator UpdateText() {
		
		foreach (char c in story){
			textfield.text += c;
			PlayAudio ();
			yield return new WaitForSeconds(timeForChar);	
		}

		Done ();
	}

	void PlayAudio() {
		if (audioPlayer.clip != null){
			audioPlayer.Play ();
		}
	}
}