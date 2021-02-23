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

        //At the start I deactivate all the RandomIdentifiers over the object
        for(int i = 1; i < objectContainer.childCount; i++)
        {
            objectContainer.GetChild(i).transform.Find("RandomIdentifier").gameObject.SetActive(false);
        }

        //I get the UsefulVariable in a variable
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        Debug.Log("The new random number is " + objectContainer.GetChild(usefulVariables.randomNumber).name);
    }

    //It generates a random number between 0 and the number of children of the object container
    public void RandomNumber()
    {
        //I get the UsefulVariable in a variable
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I get the ObjectContainer game object so that I'm able to count how many child it has
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get a random game object between the child of the parent ObjectContainer
        usefulVariables.randomNumber = Random.Range(0, objectContainer.childCount);
    }   
}