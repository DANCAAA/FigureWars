using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : NonConsumable {

	public Hair(float atack, float defense, float speed, int precio, int ind){

		atk = atack;
		def = defense;
		vel = speed;
		bought = false;
		equiped = false;
		price = precio;
        index = ind;
	}


}
