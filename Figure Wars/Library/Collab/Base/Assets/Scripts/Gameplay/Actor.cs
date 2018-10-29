using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    [SerializeField]
    protected float life,speed,atack,def;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Move()
    {

    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
