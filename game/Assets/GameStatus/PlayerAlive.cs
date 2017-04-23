using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAlive : MonoBehaviour {

	public Energy player;

	void Update () {
		if (!player.hasEnergy()) {
			Debug.Log ("Game Over");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
