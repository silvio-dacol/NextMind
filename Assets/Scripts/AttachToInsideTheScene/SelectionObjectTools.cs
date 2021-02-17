using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

public class SelectionObjectTools : MonoBehaviour
{
    //It generates a random number between 0 and the number of children of the object container
    public int RandomNumber(Transform objectContainer)
    {
        int randomNumber;

        randomNumber = Random.Range(0, objectContainer.childCount);

        return randomNumber;
    }

    //I create this Method to control if one object has been clicked/focused in the scene
    public int CumulativeSelection(int selection)
    {
        selection = selection + 1;

        Debug.Log("An object has been selected: " + selection);

        return selection;
    }    
}