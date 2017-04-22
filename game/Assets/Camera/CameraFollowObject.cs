using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour {

	public Transform t;
	public float shakeTime;
	public float shakeAmplitude;

	private bool shake;
	private float shakeTimer;

	// Update is called once per frame
	void Update () {

		// Only for debug!
		HandleTestInput ();

		if (shake) {
			shakeTimer -= Time.deltaTime;
			if (shakeTimer < 0) {
				shake = false;
			}
			var randX = Random.Range (-shakeAmplitude, shakeAmplitude);
			var randY = Random.Range (-shakeAmplitude, shakeAmplitude);
			transform.position = new Vector3 (t.position.x + randX, t.position.y + randY, transform.position.z);
		} else {
			transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);
		}
	}

	public void Shake(){
		shake = true;
		shakeTimer = shakeTime;
	}

	void HandleTestInput(){
		if (Input.GetKeyDown (KeyCode.U)) {
			Shake ();
		}
	}
}
