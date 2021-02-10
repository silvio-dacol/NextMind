using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSelectables : MonoBehaviour
{
    [Tooltip("Number of selectables you want to place in the space")]
    public int numberSelectables;

    [Tooltip("Circumference dimension: how far from the user")]
    public float radius;

    [Tooltip("Attach here the GameObject you want to replicate aroud the user")]
    public GameObject gameObject;

    void Start()
    {

        for(int i = 0; i < numberSelectables; i++)
        {
            //I divide the circumference in numberSelectables parts to create the basic angle (radians)
            double angle = i * (2f * Math.PI) / numberSelectables;

            //I specify position and rotationY of the object
            Vector3 position = new Vector3(Convert.ToSingle(radius * Math.Cos(angle)), Camera.main.transform.position.y, Convert.ToSingle(radius * Math.Sin(angle)));
            float rotationY =  90 - Convert.ToSingle(angle * (180 / Math.PI));

            Debug.Log("Angle at " + i + " is " + rotationY);
            
            //I assign the new position and rotation to the Instantiated object
            GameObject go = Instantiate(gameObject, position, Quaternion.Euler(0, rotationY, 0));
        }
    }
}
