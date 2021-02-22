using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When a new scene is loaded, the selectionCount in ObjectSelectionTriggered is reset to zero

//Attach this script to the task buttons and add the Method to the OnClick() event

public class ResetVariableCount : MonoBehaviour
{
    public void ResetTheCount()
    {
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I reset the variables in the UsefulVariables script
        usefulVariables.selectionCount = 0;
        usefulVariables.randomNumber = 0;
        usefulVariables.rightObjectSelection = 0;
        usefulVariables.wrongObjectSelection = 0;
        usefulVariables.totalTimeInTheScene = 0;
        usefulVariables.timeOfSingleSelection = 0;
    }
}
