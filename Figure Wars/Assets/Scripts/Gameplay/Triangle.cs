using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Character {

    [SerializeField]
    private GameObject flecha;
    private bool disparando = false;
    

   

    // Use this for initialization
    void Start () {

        atacking = false;
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!atacking)
        {
            Move();
            anim.SetInteger("Estado", 2);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(1,-0.1f,0), Vector2.right, 7f);

        if (hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Enemy" && !disparando)
            {
                Atacar();
                disparando = true;
                atacking = true;
                StartCoroutine(PuedeDisparar());
            }
        }else
        {
            atacking = false;
        }

        if (life <= 0)
        {
            anim.SetInteger("Estado", 3);
            Invoke("Die", 2f);
        }

        lifetext.GetComponent<TextMesh>().text = life.ToString();
    }

    public override void Atacar()
    {
        anim.SetInteger("Estado", 1);
        GameObject proyectil = Instantiate(flecha, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
        proyectil.gameObject.GetComponent<Flecha>().damage = atack;       
        StartCoroutine(idle());
    }

    public IEnumerator PuedeDisparar()
    {
        yield return new WaitForSeconds(atkspeed);
        disparando = false;
    }

    private IEnumerator idle()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetInteger("Estado", 0);
    }
}
