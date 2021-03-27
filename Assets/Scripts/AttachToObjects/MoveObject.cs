using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the objects in the scene

public class MoveObject : MonoBehaviour
{
    //How much I want this thing to move
    private Vector3 deltaPosition;

    [Tooltip("The direction along which the object moves")]
    [SerializeField] private Vector3 normalisedPositionVector;

    [Tooltip("Speed to go from point A to point B")]
    [SerializeField] private float speed;

    [Tooltip("The range (+/-) used to access the vector direction")]
    [SerializeField] private float range;

    //The index allowing to change direction back and forth
    private int changeDirectionIndex;

    //How many frames wait before changing direction
    [SerializeField] private int deltaFrames;

    //The frame when I start to count
    private int initialFrames;

    private void Start()
    {
        if (gameObject.scene.name == "Task3")
        {
            speed = 0.2f;
            range = 0.5f;

            //I define the deltaFrames to change direction just between 700 and 900
            deltaFrames = Random.Range(300, 500);
        }

        else if (gameObject.scene.name == "Task4")
        {
            speed = 0.4f;
            range = 0.5f;

            //I define the deltaFrames to change direction just between 700 and 900
            deltaFrames = Random.Range(150, 250);
        }

        if (gameObject.name == "NoBoxObject")
        {
            MoveObject moveObject = gameObject.GetComponent<MoveObject>();

            Destroy(moveObject);
        }

        //It's a random direction for the movement of that specific object
        deltaPosition = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));

        //This will be the actual direction of my movement
        normalisedPositionVector = deltaPosition.normalized;

        //I initialise the initialFrames at zero
        initialFrames = Time.frameCount;
    }

    private void Update()
    {
        //Move just if I have clicked the button
        if (changeDirectionIndex == 0)
        {
            gameObject.transform.position = gameObject.transform.position + (normalisedPositionVector * speed * Time.deltaTime);

            if(Time.frameCount - initialFrames >= deltaFrames)
            {
                //I initialise again the initialFrames for the next position changing
                initialFrames = Time.frameCount;

                //I change the changeDirectionIndex, so the script can enter the other if statement
                changeDirectionIndex = 1;
            }
        }

        else if(changeDirectionIndex == 1)
        {
            gameObject.transform.position = gameObject.transform.position + (-normalisedPositionVector * speed * Time.deltaTime);

            if (Time.frameCount - initialFrames >= deltaFrames)
            {
                initialFrames = Time.frameCount;

                changeDirectionIndex = 0;
            }
        }
    }
}
