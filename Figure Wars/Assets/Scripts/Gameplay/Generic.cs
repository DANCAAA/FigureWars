using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : Enemy {
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
        lifetext.GetComponent<TextMesh>().text = life.ToString();

        if(life <= 0)
        {
            Destroy(gameObject);
        }

    }

    public override void Atacar()
    {
        throw new System.NotImplementedException();
    }

}
