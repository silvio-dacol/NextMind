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
        //I get the UsefulVariable in a variable
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I print on the Console the first randomValue of the sequence
        Debug.Log("The random number is " + usefulVariables.randomNumber);
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