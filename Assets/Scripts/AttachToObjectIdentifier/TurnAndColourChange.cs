using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the yellow box in each object

public class TurnAndColourChange : MonoBehaviour
{
    private int rotationSpeed = 35;
    private float offset = 0.3f;

    private void Start()
    {
        //I change the colour of the RandomIdentifier
        ChangeColour();
    }

    void Update()
    {
        //I make the RandomIdentifier rotating over the object
        gameObject.transform.Rotate(gameObject.GetComponentInParent<Transform>().up * rotationSpeed * Time.deltaTime);
    }

    private void RandomIdentifierMover()
    {
        //I initialise all the Random Identifiers at (0, 0, 0)
        gameObject.GetComponent<Transform>().position = new Vector3(0, 0, 0);

        //I set the new position of the Random Identifier
        gameObject.GetComponent<Transform>().position = new Vector3(0, (gameObject.GetComponentInParent<Transform>().localScale.y / 2) + offset, 0);
    }

    private void ChangeColour()
    {
        //Get the Renderer component from the new cube
        Renderer cubeRenderer = gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.yellow);
    }
}
