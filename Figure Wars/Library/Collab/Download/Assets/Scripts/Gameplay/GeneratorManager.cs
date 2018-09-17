using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GeneratorManager : MonoBehaviour {

    [SerializeField]
    private Character[] characters;
	[SerializeField]
	private GameObject[] lines;
	[SerializeField]
	private DragCharacter[] draggables;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCharacter(int index, int line)
    {
		Instantiate (characters [index], lines [line].transform.position, transform.rotation);
    }

	public void SpawnDragCharacter(int index){

        if (!draggables[0].activo && !draggables[1].activo && !draggables[2].activo)
        {
            draggables[index].activo = true;
        }
	}

}
