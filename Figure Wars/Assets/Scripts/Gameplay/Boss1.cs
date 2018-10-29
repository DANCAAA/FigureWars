using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy {
    private bool atacando;
    [SerializeField]
    private GameObject proyectil;

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

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-2f, -0.1f, 0), Vector2.left, 3f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Character" && !atacando)
            {
                anim.SetInteger("Estado", 1);
                Invoke("Atacar", 0.30f);
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
        int num = Random.Range(0, 2);

        if (num == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Invoke("ColliderFuera", 0.1f);
        }
        else
        {
            GameObject proyectill = Instantiate(proyectil, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            proyectill.gameObject.GetComponent<FlechaE>().damage = atack;
            StartCoroutine(idle());
        }
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

    private IEnumerator idle()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetInteger("Estado", 0);
    }
}
