using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the task scenes

public class SwitchOnObjectsMovement : MonoBehaviour
{
    void Start()
    {
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            if(gameObject.scene.name == "Task3")
            {
                objectContainer.GetChild(i).GetComponent<MoveObject>().enabled = true;
            }

            else
            {
                objectContainer.GetChild(i).GetComponent<MoveObject>().enabled = false;
            }
        }
    }
}
