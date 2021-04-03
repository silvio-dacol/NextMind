using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to Task1, Task3 and Task4 to reduce the dimension of the objects

public class ReduceObjectDimension : MonoBehaviour
{
    public float localScale = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        //I get the objectContainer Game Object with all the selectables inside
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get the scene name to differentiate dimensions of the objects
        //if (gameObject.scene.name == "Task2")
        //{
            //localScale = 1f;
        //}

        //else
        //{
            localScale = 0.6f;
        //}

        //I reduce the dimension of the objects in the scene
        for (int i = 0; i < objectContainer.childCount; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(localScale, localScale, localScale);
        }
    }
}
