using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterSpawner : MonoBehaviour {

	public GameObject splatterObj;

	public void SpawnSplatter(){
		Vector2 pos = transform.position;
		GameObject clone = Instantiate (splatterObj);
		clone.transform.position = pos;
		clone.GetComponent<SpriteRenderer> ().color = GetComponent<SpriteRenderer> ().color;
	}
}