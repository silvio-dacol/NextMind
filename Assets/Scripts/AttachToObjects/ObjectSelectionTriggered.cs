﻿using System.Collections;
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
        //I measure the accuracy of selection by comparing if the selected object child number correspond with the randomNumber

        //I store the objectIndex in a variable
        int objectIndex;

        //I store in the variable RandomNumber the new value
        int randomNumber = usefulVariables.randomNumber;

        //I save the index of the clicked object in the objectIndex variable
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





        //
        //When the comparison finished, I call again the RandomNumberGenerator to obtain a new randomNumber

        RandomNumberGenerator randomNumberGenerator = FindObjectOfType<RandomNumberGenerator>();

        randomNumberGenerator.RandomNumber();

        //Provvisorioooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo per vedere se funzia
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;
        Debug.Log("The new random number is " + objectContainer.GetChild(usefulVariables.randomNumber).name);





        //
        //Now I activate the randomIdentifier of the new object and deactivate all the others
        //Deactivate all the identifiers
        for (int i = 0; i < objectContainer.childCount; i++)
        {
            objectContainer.GetChild(i).transform.Find("RandomIdentifier").gameObject.SetActive(false);
        }

        //Activate the one I need respect to the new random object so that the user can understand which one he could select
        objectContainer.GetChild(usefulVariables.randomNumber).transform.Find("RandomIdentifier").gameObject.SetActive(true);





        //
        //I increase the counter of the number of times an object is selected

        usefulVariables.selectionCount = usefulVariables.selectionCount + 1;
        //Debug.Log("The objects has been hit " + usefulVariables.selectionCount + " times");
    }
}