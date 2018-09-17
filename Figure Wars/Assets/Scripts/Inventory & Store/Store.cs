using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
	public List<NonConsumable> items;
	public Inventory playerInventory;
    [SerializeField]
    private UImanager ui;

	void Awake (){
	
		NonConsumable	armorBase = new Armor (1, 3, -2, 100, false,0);
		NonConsumable	armorMedium = new Armor (0, 8, -4,200, false,1);
		NonConsumable	armorHard = new Armor (-1, 10, -3, 300, false,2);
		NonConsumable	armorSoft = new Armor (3, 6, 2, 500, false,3);

		NonConsumable weaponSword = new Weapon (5, -1, 3, 100, false,4);
		NonConsumable weaponHamer = new Weapon(8,1,-4,200,false,5);
		NonConsumable weaponLance = new Weapon(3,2,5,250, false,6);
		NonConsumable weaponKnife = new Weapon (5, 2, 6, 500, false,7);

		NonConsumable hairLarge = new Hair (3, 4, 1, 100,8);
		NonConsumable hairMedium = new Hair (4, 4, 3, 200,9);
		NonConsumable hairshort = new Hair (1, 6, 6, 200,10);
		NonConsumable hairNone = new Hair (3, 8, 7, 400,11);

		items.Add (armorBase);
        items.Add(armorMedium);
        items.Add(armorHard);
		items.Add(armorSoft);
		

		items.Add(weaponSword);
		items.Add(weaponHamer);
		items.Add(weaponLance);
		items.Add (weaponKnife);

		items.Add (hairLarge);
		items.Add (hairMedium);
		items.Add (hairshort);
		items.Add (hairNone);

        //Metodo sin implementar
		ToList ();

	}

	public void Sell(int index)
    {
		if (index <= 11) {

			NonConsumable itm = items [index];
			if (itm.price <= playerInventory.oro) {

				if (!itm.bought) {
					playerInventory.items.Add (itm);
					playerInventory.oro -= itm.price;
					items[index].bought = true;
                    ui.CompraExitosa(index);
                } else {

                    ui.LoTienes();
				} 

			} else {

                ui.SinDinero();
			}
		} else {
			if (index == 12) {

				if (playerInventory.powerUps [0].price < playerInventory.oro) {

					playerInventory.powerUps [0].cantidad += 1;
					playerInventory.oro -= playerInventory.powerUps [0].price;
                    ui.CompraExitosa(index);

				} else {
                    ui.SinDinero();
                }
			}

			if (index == 13) {

				if (playerInventory.powerUps [1].price < playerInventory.oro) {

					playerInventory.powerUps [1].cantidad += 1;
					playerInventory.oro -= playerInventory.powerUps [1].price;
                    ui.CompraExitosa(index);
                } else {
                    ui.SinDinero();
                }
			}

			if (index == 14) {

				if (playerInventory.powerUps [2].price < playerInventory.oro) {

					playerInventory.powerUps [2].cantidad += 1;
					playerInventory.oro -= playerInventory.powerUps [2].price;
                    ui.CompraExitosa(index);
                } else {
                    ui.SinDinero();
                }
			}

    	}
	}

    //Metodo sin implementar
	public void ToList(){

		for (int i = 0; i < items.Count; i++) {


		}
		
	}
}
