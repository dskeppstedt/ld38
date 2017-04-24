using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class ShowObjectsOnCollision : MonoBehaviour {

	public GameObject[] thingsToShow;

	// Use this for initialization
	void Start () {

		foreach(GameObject go in thingsToShow) {
			go.SetActive (false);
		}


	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			foreach(GameObject go in thingsToShow) {
				go.SetActive (true);
			}	
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			foreach (GameObject go in thingsToShow) {
				go.SetActive (false);
			}
		}
	}

}