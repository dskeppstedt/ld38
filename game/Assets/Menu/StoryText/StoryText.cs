using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class StoryText : MonoBehaviour {
	
	public Text textfield;
	public float timeForChar;

	AudioSource audioPlayer;

	string story = "Nucelar war was the apocalypse on Earth. In a bunker in the darkest of depths lies humanites only hope. A direct connection to the Moon has the ability to wake a few humans from cryo-sleep. Their only missions is to get to the awaiting space rocket. The space rocket will take them to the new world on the Moon and they will help to rebuild humankind.\n\nThere is only one problem, the path between the cryo room and the rocket launch pad has been breatched and all kinds of horrors wander these halls. Stay safe and save humanity!";

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