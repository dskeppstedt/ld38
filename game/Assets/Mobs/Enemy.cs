using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

	public MobType mobType;

	private Transform defaultParent;

	// Use this for initialization
	void Start () {
		defaultParent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable(){
		ReturnToPool ();
	}

	void ReturnToPool(){
		transform.parent = defaultParent;
	}
}
