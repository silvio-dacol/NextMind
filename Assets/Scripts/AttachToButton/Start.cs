using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the "Start" OnClick() event

public class Start : MonoBehaviour
{
    private float secondsToWait = 4.0f;

    //This method creates a Random Number which will be assigned to the first element in the scene
    public void SwitchOnSelectionElements()
    {
        StartCoroutine(Wait(secondsToWait));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //I get the ObjectContainer game object so that I'm able to count how many child it has
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get the UsefulVariables script (it contains all the variable needed to be stored)
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I get the RandomNumberGenerator script
        RandomNumberGenerator randomNumberGenerator = GameObject.Find("RandomNumberGenerator").GetComponent<RandomNumberGenerator>();

        randomNumberGenerator.RandomNumber();

        //Activate the one I need respect to the new random object so that the user can understand which one he could select
        objectContainer.GetChild(usefulVariables.randomNumber).transform.Find("RandomIdentifier").gameObject.SetActive(true);
    }
}
