﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Character {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
