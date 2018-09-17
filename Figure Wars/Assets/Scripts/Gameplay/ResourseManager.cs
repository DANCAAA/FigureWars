using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourseManager : MonoBehaviour {

    public int gold;

    [SerializeField]
    private Text goldtext;
    [SerializeField]
    private int amountPerTime;
    [SerializeField]
    private float addGoldInterval;

	// Use this for initialization
	void Start () {

        goldtext.text = gold.ToString();
        InvokeRepeating("AddGoldPerTime", 0f, addGoldInterval);
	}


    public void AddGold(int add)
    {
        gold += add;
        goldtext.text = gold.ToString();
    }

    public void AddGoldPerTime()
    {
        gold += amountPerTime;
        goldtext.text = gold.ToString();
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
        goldtext.text = gold.ToString();
    }
}
