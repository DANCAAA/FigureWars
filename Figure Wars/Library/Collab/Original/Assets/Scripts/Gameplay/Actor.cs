using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour {

    public float life,speed,atack,def,atkspeed;
    protected bool atacking;

	
	// Update is called once per frame
	

    public virtual void Move()
    {

    }

    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    

}
