using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDef : Consumable {

	public PowerDef(int precio, float porcentaje, float duracion)
    {	 
		price = precio;
		duration = duracion;
		percent = porcentaje;
		cantidad = 0;
	}

	public void Consume(){
		
	}
}
