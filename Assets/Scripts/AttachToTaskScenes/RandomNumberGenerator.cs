using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

//Script to be attached inside the scene

public class RandomNumberGenerator : MonoBehaviour
{
    private void Start()
    {
        //I get the ObjectContainer game object so that I'm able to count how many child it has
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get the usefulVariables script (it contains all the variable needed to be stored)
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            //At the start I deactivate all the RandomIdentifiers over the object
            objectContainer.GetChild(i).transform.Find("RandomIdentifier").gameObject.SetActive(false);

            //At the start I activate the Interactable components of all the objects
            objectContainer.GetChild(i).GetComponent<Interactable>().enabled = true;
            GameObject.Find("HoloLensToggle").GetComponent<Interactable>().IsToggled = true;

            //At the start I deactivate the NeuroTag component of all the objects
            objectContainer.GetChild(i).GetComponent<NeuroTag>().enabled = false;
            GameObject.Find("NextMindToggle").GetComponent<Interactable>().IsToggled = false;
        }

        //This for() controls if there will be the box or not on the objects
        for (int i = 0; i < usefulVariables.numberOfSelections; i++)
        {
            //There will be the 70% possibilities to be in the case of a box and the 30% not to be
            if (Random.Range(0, 10) < 7)
            {
                usefulVariables.boxOrNoBox[i] = 1;
            }

            else
            {
                usefulVariables.boxOrNoBox[i] = 0;
            }
        }
    }

    //It generates a random number between 0 and the number of children of the object container
    public void RandomNumber()
    {
        //I get the UsefulVariable in a variable
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I get the ObjectContainer game object so that I'm able to count how many child it has
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get a random game object between the child of the parent ObjectContainer
        usefulVariables.randomNumber = Random.Range(0, objectContainer.childCount - 1);
    }   
}