using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int oro = 1000;
    public List<NonConsumable> items;
	public List<Consumable> powerUps;

    [SerializeField]
    private List<NonConsumable> equipables = new List<NonConsumable>();
    private int[] posicionesEquipables = new int[] {0,0,0};

    [SerializeField]
    private UImanager ui;

	void Start (){

		Consumable speed = new PowerSpeed (100, 20, 6) as Consumable;
		Consumable atack = new PowerAtk (150, 30, 10) as Consumable;
		Consumable def = new PowerDef (150, 40, 7) as Consumable;

		powerUps.Add(speed);
		powerUps.Add(atack);
		powerUps.Add(def);
		Debug.Log ("listo");

        equipables.Add(null);
        equipables.Add(null);
        equipables.Add(null);
	}

	public void Consume(int index)
    {
        if (index == 0)
        {
            if (powerUps[0].cantidad > 0)
            {
                powerUps[0].Consume();
                powerUps[0].cantidad -= 1;
                ui.Consumido();
            }
            else
            {
                ui.SinConsumible();
            }
        }

        if (index == 1)
        {
            if (powerUps[1].cantidad > 0)
            {
                powerUps[1].Consume();
                powerUps[1].cantidad -= 1;
                ui.Consumido();
            }
            else
            {
                ui.SinConsumible();
            }
        }

        if (index == 2)
        {
            if (powerUps[2].cantidad > 0)
            {
                powerUps[2].Consume();
                powerUps[2].cantidad -= 1;
                ui.Consumido();
            }
            else
            {
                ui.SinConsumible();
            }
        }

    }


    public void Equip(int index)
    {
        if (!items[index].equiped) { 
            for (int i = 0; i < 3; i++)
            {
                if (posicionesEquipables[i] == 0 && !items[index].equiped)
                {
                    equipables[i] = items[index];
                    items[index].equiped = true;
                    ui.Equipar(i, index);
                    posicionesEquipables[i] = 1;
                    break;
                }

                if (i == 2)
                {
                    Debug.Log("Ya tienes 3 items equipados");
                }
            }
        }

    }

    public void UnEquip( int index)
    {
        int itm = equipables[index].index;
        equipables[index] = null;
        posicionesEquipables[index] = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if(itm == items[i].index)
            {
                items[i].equiped = false;
                break;
            }
        }
        ui.Desequipar(index);
    }    
    
	public void Discard(int index, int cantidad)
    {
		if (index == 0) {
			oro += Mathf.RoundToInt((powerUps[0].price / 2f) * cantidad);
            powerUps[0].cantidad -= cantidad;
            ui.DescarteExitoso(Mathf.RoundToInt((powerUps[1].price / 2f) * cantidad));
		}

        if (index == 1)
        {
            oro += Mathf.RoundToInt((powerUps[1].price / 2f) * cantidad);
            powerUps[1].cantidad -= cantidad;
            ui.DescarteExitoso(Mathf.RoundToInt((powerUps[1].price / 2f) * cantidad));
        }

        if (index == 2)
        {
            oro += Mathf.RoundToInt((powerUps[2].price / 2f) * cantidad);
            powerUps[2].cantidad -= cantidad;
            ui.DescarteExitoso(Mathf.RoundToInt((powerUps[1].price / 2f) * cantidad));
        }
    }
}
