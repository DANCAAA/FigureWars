using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    [SerializeField]
    private float life;
    [SerializeField]
    private float reconstructionTime;
    [SerializeField]
    private GameObject lifetext;


    public void TakeDamage(float amount)
    {
        life -= amount;
        lifetext.GetComponent<TextMesh>().text = life.ToString();
    }

    public void Reconstruction(float amount)
    {
        life += amount;
        lifetext.GetComponent<TextMesh>().text = life.ToString();
    }
}
