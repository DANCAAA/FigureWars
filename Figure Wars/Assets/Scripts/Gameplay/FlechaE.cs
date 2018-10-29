using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaE : MonoBehaviour {

    [SerializeField]
    private float velocidad;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vharacter")
        {
            collision.gameObject.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
