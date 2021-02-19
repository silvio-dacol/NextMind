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
        CheckSelectionCorrectness checkSelectionCorrectness = FindObjectOfType<CheckSelectionCorrectness>();
        
        checkSelectionCorrectness.selectionCount = checkSelectionCorrectness.selectionCount + 1;      
            
        Debug.Log("The objects has been hit " + checkSelectionCorrectness.selectionCount + " times");
    }
}
