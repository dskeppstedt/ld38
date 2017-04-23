using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This shows the energy level of the player...
public class EnergyText : MonoBehaviour {

	Energy playerEnergy;
	Text energyText;

	// Use this for initialization
	void Start () {
		playerEnergy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Energy> ();
		if (playerEnergy == null) {
			Debug.LogError ("Player has no Energy component");
		}

		energyText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		energyText.text = "Energy: " + playerEnergy.getEnergy ();
	}
}
