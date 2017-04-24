using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Splatter : MonoBehaviour {
		
	public Sprite [] splatters;

	// Use this for initialization
	void Start () {
		Sprite randomSplatter = splatters [Random.Range (0, splatters.Length)];
		GetComponent<SpriteRenderer> ().sprite = randomSplatter;
	}

}
