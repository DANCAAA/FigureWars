using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : NonConsumable {

	public Weapon(float atack, float defense, float speed, int precio, bool comprado, int ind)
    {
		atk = atack;
		def = defense;
		vel = speed;
		bought = comprado;
		equiped = false;
		price = precio;
        index = ind;
	}
}
