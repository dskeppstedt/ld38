using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	public int initialEnergy = 300;
	int energy;

	public bool alive;//TODO hide from editor

	public void Start() {
		this.energy = initialEnergy;
	}

	public bool ReduceEnergy(int amount) {
		if (energy - amount < 0) {
			return false;
		}

		energy -= amount;
		return true;
	}

	public bool hasEnergy() {
		return energy > 0;
	}

	public int getEnergy() {
		return energy;
	}

	public void setEnergy(uint energy) {
		this.energy = (int) energy;
	}

}