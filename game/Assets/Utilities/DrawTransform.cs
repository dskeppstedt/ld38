using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTransform : MonoBehaviour {

	public Color color;

	void OnDrawGizmos(){
		Gizmos.color = color;
		Gizmos.DrawCube (transform.position, Vector3.one);
	}
}
