using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

	public string scene;
	public float delay;

	// Use this for initialization
	void Start () {
		StartCoroutine ("SwitchScene");
	}

	IEnumerator SwitchScene () {
		yield return new WaitForSeconds (delay);
		Application.LoadLevel (scene); //TODO: Update to SceneManager
	}

}
