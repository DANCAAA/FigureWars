using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour {

    [SerializeField]
    private float life;
    [SerializeField]
    private float reconstructionTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float amount)
    {
        life -= amount;
    }

    public void Reconstruction(float amount)
    {
        life += amount;
    }
}
