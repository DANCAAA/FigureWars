using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCharacter : MonoBehaviour {

    private bool top;
    private bool midle;
    private bool down;

    private int index;
    private Sprite sprite;

    private GeneratorManager generator;

    // Update is called once per frame

    public DragCharacter(int indexIN, Sprite spriteIN)
    {
        index = indexIN;
        sprite = spriteIN;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            transform.position = Camera.main.ScreenToWorldPoint(touch.position);

            if((touch.phase == TouchPhase.Ended)|| (touch.phase == TouchPhase.Canceled))
            {
                Drop();
            }
        }
    }

    private void Drop()
    {
        if (top)
        {
            generator.SpawnCharacter(index, 1);
            Destroy(gameObject);
        }
        else if (midle)
        {
            generator.SpawnCharacter(index, 2);
            Destroy(gameObject);
        }
        else if (down)
        {
            generator.SpawnCharacter(index, 3);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LineTop")
        {
            top = true;
        }

        if (other.gameObject.tag == "LineMidle")
        {
            midle = true;
        }

        if (other.gameObject.tag == "LineDown")
        {
            down = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LineTop")
        {
            top = false;
        }

        if (other.gameObject.tag == "LineMidle")
        {
            midle = false;
        }

        if (other.gameObject.tag == "LineDown")
        {
            down = false;
        }
    }

}
