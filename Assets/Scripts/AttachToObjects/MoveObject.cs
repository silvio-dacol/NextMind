using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the objects in the scene

public class MoveObject : MonoBehaviour
{
    float speed;
    float speedMultiplier;
    int randomNumber;

    void Start()
    {
        //I get a random game object between the child of the parent ObjectContainer
        randomNumber = Random.Range(0, 2);

        //I set the speedMultiplier
        speedMultiplier = 3;

        //I set the speed of movement
        speed = randomNumber * speedMultiplier;
    }

    void Update()
    {
        if (randomNumber == 0)
        {
            Movement0();
        }

        if (randomNumber == 1)
        {
            Movement1();
        }

        if (randomNumber == 2)
        {
            Movement2();
        }
    }

    private void Movement0()
    {
        
    }

    private void Movement1()
    {
        
    }

    private void Movement2()
    {

    }
}
