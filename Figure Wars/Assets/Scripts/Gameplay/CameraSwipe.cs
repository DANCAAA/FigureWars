using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private GeneratorManager generator;


    // Update is called once per frame
    void Update()
    {
        

        if (!generator.draggables[0].activo && !generator.draggables[1].activo && !generator.draggables[2].activo)
        {
            if (Input.touchCount > 0)
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    {
                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        Debug.Log(touchDeltaPosition);
                        transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
                    }
                }

            if (transform.position.x < 0)
            {
                Vector3 newp = new Vector3(0, transform.position.y, transform.position.z);
                transform.position = newp;
            }

            if (transform.position.x > 38.1)
            {
                Vector3 newp = new Vector3(38.1f, transform.position.y, transform.position.z);
                transform.position = newp;
            }
        }
    }
}
