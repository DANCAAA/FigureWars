using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Actor {

  

    public override void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }


    public override void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("colisionando");
        if (collision.gameObject.tag == "Enemy" && !atacking)
        {
            Atack(collision.gameObject);
            atacking = true;
            StartCoroutine("atackingoff");
        }

        if(collision.gameObject.tag == "Castle")
        {
            collision.gameObject.GetComponent<Castle>().TakeDamage(atack);
            Destroy(gameObject);
        }
    }

    private void Atack(GameObject target)
    {
        target.GetComponent<Enemy>().life -= (atack - target.GetComponent<Enemy>().def / 2);

    }

    public IEnumerator atackingoff()
    {
        yield return new WaitForSeconds(atkspeed);
        atacking = false;
    }
}
