using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

//Script to be attached to the different objects in the scene

public class ObjectSelectionTriggered : MonoBehaviour
{
    public void IncreaseSelectionCount()
    {
        //
        //I get the usefulVariables script (it contains all the variable needed to be stored)

        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();





        //
        //When the comparison starts, I call the RandomNumberGenerator to obtain a new randomNumber

        RandomNumberGenerator randomNumberGenerator = FindObjectOfType<RandomNumberGenerator>();

        randomNumberGenerator.RandomNumber();

        //I store in the variable RandomNumber the new value
        int randomNumber = usefulVariables.randomNumber;

        //Provvisorioooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo per vedere se funzia
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;
        Debug.Log("The new random number is " + objectContainer.GetChild(randomNumber).name);




        //
        //I increase the counter of the number of times an object is selected

        usefulVariables.selectionCount = usefulVariables.selectionCount + 1;
        //Debug.Log("The objects has been hit " + usefulVariables.selectionCount + " times");





        //
        //I measure the accuracy of selection by comparing if the selected object child number correspond with the randomNumber

        int objectIndex;

        //I save the objectIndex in a variable
        objectIndex = gameObject.transform.GetSiblingIndex();

        //If the selected object is the right one, increase the rightObjectSelection
        if(objectIndex == randomNumber)
        {
            usefulVariables.rightObjectSelection = usefulVariables.rightObjectSelection + 1;
        }

        //If the selected object is the wrong one, increase the wrongObjectSelection
        else if(objectIndex != randomNumber)
        {
            usefulVariables.wrongObjectSelection = usefulVariables.wrongObjectSelection + 1;
        }
    }
}
