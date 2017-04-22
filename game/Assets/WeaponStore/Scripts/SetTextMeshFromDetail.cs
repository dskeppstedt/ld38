using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextMeshFromDetail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int price = GetComponentInParent<WeaponItemDetail> ().price;
		GetComponent<TextMesh> ().text = price + "$";
	}
}
