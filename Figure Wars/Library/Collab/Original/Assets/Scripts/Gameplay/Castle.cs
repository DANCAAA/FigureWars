using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    [SerializeField]
    private float life;
    [SerializeField]
    private float reconstructionTime;


    public void TakeDamage(float amount)
    {
        life -= amount;
    }

    public void Reconstruction(float amount)
    {
        life += amount;
    }
}
