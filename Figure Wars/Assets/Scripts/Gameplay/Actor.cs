using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Actor : MonoBehaviour {

    public float life,speed,atack,def,atkspeed;
    protected bool atacking;
    [SerializeField]
    protected GameObject lifetext;
    protected Animator anim;


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

    public abstract void Atacar();

}
