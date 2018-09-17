using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor {


    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    

    public override void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Character" && !atacking)
        {
            Atack(collision.gameObject);
            atacking = true;
            StartCoroutine("atackingoff");
        }
        if (collision.gameObject.tag == "Castle")
        {
            collision.gameObject.GetComponent<Castle>().TakeDamage(atack);
            Destroy(gameObject);
            
        }
    }

    private void Atack(GameObject target)
    {
        target.GetComponent<Character>().life -= (atack - target.GetComponent<Character>().def /2);

    }

    public IEnumerator atackingoff()
    {
        yield return new WaitForSeconds(atkspeed);
        atacking = false;
    }

}
