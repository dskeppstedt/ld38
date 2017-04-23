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

	public void ReduceEnergy(int amount) {
		energy -= amount;
	}

	public void IncreaseEnergy(int amount) {
		energy += amount;
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