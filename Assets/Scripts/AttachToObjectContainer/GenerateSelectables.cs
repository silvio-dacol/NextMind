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
    public GameObject element;

    //variables relative to the method RandomIdentifierMover()
    private float offset = 0.3f;
    private GameObject randomIdentifier;

    private void Start()
    {
        for (int i = 0; i < numberSelectables; i++)
        {
            //I divide the circumference in numberSelectables parts to create the basic angle (radians)
            double angle = i * (2f * Math.PI) / numberSelectables;

            //I specify position and rotationY of the object
            Vector3 position = new Vector3(Convert.ToSingle(radius * Math.Cos(angle)), Camera.main.transform.position.y, Convert.ToSingle(radius * Math.Sin(angle)));
            float rotationY = 90 - Convert.ToSingle(angle * (180 / Math.PI));

            //I assign the new position and rotation to the Instantiated object
            GameObject go = Instantiate(element, position, Quaternion.Euler(0, rotationY, 0));

            //I move the Random Identifiers over the spawned object
            RandomIdentifierMover();

            //I change the colour of the RandomIdentifier
            ChangeColour();

            //I deactivate all the Random Identifiers
            //randomIdentifier.active = false;
        }
    }

    private void RandomIdentifierMover()
    {
        //I get the Random Identifier that I want
        randomIdentifier = element.transform.Find("RandomIdentifier").gameObject;

        //I initialise all the Random Identifiers at (0, 0, 0)
        randomIdentifier.GetComponent<Transform>().position = new Vector3(0, 0, 0);

        //I set the new position of the Random Identifier
        randomIdentifier.GetComponent<Transform>().position = new Vector3(0, (element.GetComponent<Transform>().localScale.y / 2) + offset, 0);
    }

    private void ChangeColour()
    {
        randomIdentifier.GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
    }
}
