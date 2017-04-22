using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableOnPress : MonoBehaviour {

	public GameObject toDisable;
	public GameObject toEnable;

	public void onPress() {
		toDisable.SetActive (false);
		toEnable.SetActive (true);
	}

}
