using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCharacter : MonoBehaviour {

	[SerializeField]
    private bool top, midle, down;
	[SerializeField]
    private int index;
	[SerializeField]
    private GeneratorManager generator;
	[SerializeField]
	private GameObject initialposition;
    public int price;

	public bool activo;

    void Update()
    {
		if (Input.touchCount > 0 && activo)
        {
            Touch touch = Input.GetTouch(0);

			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x,touch.position.y,5f));

            if((touch.phase == TouchPhase.Ended)|| (touch.phase == TouchPhase.Canceled))
            {
                Drop();
				activo = false;
            }
        }
    }

    private void Drop()
    {
        if (top)
        {
            generator.SpawnCharacter(index, 0, price);
            transform.position = initialposition.transform.position;
        }
        else if (midle)
        {
            generator.SpawnCharacter(index, 1, price);
            transform.position = initialposition.transform.position;
            transform.position = initialposition.transform.position;
        }
        else if (down)
        {
            generator.SpawnCharacter(index, 2, price);
            transform.position = initialposition.transform.position;
			transform.position = initialposition.transform.position;
        }

		transform.position = initialposition.transform.position;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LineTop")
        {
            top = true;
        }

        if (collision.gameObject.tag == "LineMidle")
        {
            midle = true;
        }

        if (collision.gameObject.tag == "LineDown")
        {
            down = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LineTop")
        {
            top = false;
        }

        if (collision.gameObject.tag == "LineMidle")
        {
            midle = false;
        }

        if (collision.gameObject.tag == "LineDown")
        {
            down = false;
        }
    }


}
