using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableOnPress : MonoBehaviour {

	public GameObject toDisable;
	public GameObject toEnable;

	public void onPress() {

		if (toDisable != null) {
			toDisable.SetActive (false);
		}
		if (toEnable != null) {
			toEnable.SetActive (true);
		}
	}

}
