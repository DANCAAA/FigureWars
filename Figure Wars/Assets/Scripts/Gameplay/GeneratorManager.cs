using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class GeneratorManager : MonoBehaviour {

    [SerializeField]
    private Character[] characters;
	[SerializeField]
	private GameObject[] lines;
	public DragCharacter[] draggables;

    [SerializeField]
    private ResourseManager resources;

    [SerializeField]
    private Enemy[] enemies;
    [SerializeField]
    private Transform[] spawnPointsEnemies; 

	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnEnemy", 0, Random.Range(5f, 10f));
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCharacter(int index, int line, int price)
    {
		Instantiate (characters [index], lines [line].transform.position, transform.rotation);
        resources.RemoveGold(price);
    }

	public void SpawnDragCharacter(int index){

        if (!draggables[0].activo && !draggables[1].activo && !draggables[2].activo)
        {
            draggables[index].activo = true;
        }
	}

    public void SpawnEnemy()
    {
        Instantiate(enemies[0], spawnPointsEnemies[Random.Range(0,3)].position, transform.rotation);
    }


}
