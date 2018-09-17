using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, /*IDragHandler,IEndDragHandler*/ IPointerEnterHandler
{

	[SerializeField]
	private int index;
	[SerializeField]
	private GeneratorManager generator;
    [SerializeField]
    private ResourseManager resourses;


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (generator.draggables[index].price <= resourses.gold)
        {
            generator.SpawnDragCharacter(index);
        }
        else
        {
            Debug.Log("Sin dinero");
        }
    }
}
