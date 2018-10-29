using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : Character
{
    private bool atacando;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (!atacking)
        {
            Move();
            anim.SetInteger("Estado", 2);
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.7f, -0.1f, 0), Vector2.right, 0.005f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy" && !atacando)
            {
                anim.SetInteger("Estado", 1);
                Invoke("Atacar", 0.50f);
                atacando = true;
                atacking = true;
                StartCoroutine(PuedeAtacar());
            }
        }
        else
        {
            atacking = false;
        }

        lifetext.GetComponent<TextMesh>().text = life.ToString();
    }

    public override void Atacar()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("ColliderFuera", 0.1f);
    }

    private void ColliderFuera()
    {
        anim.SetInteger("Estado", 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public IEnumerator PuedeAtacar()
    {
        yield return new WaitForSeconds(atkspeed);
        atacando = false;
    }
}
