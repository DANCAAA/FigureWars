using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : NonConsumable {

	public Armor(float atack, float defense, float speed, int precio, bool comprado, int ind)
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
