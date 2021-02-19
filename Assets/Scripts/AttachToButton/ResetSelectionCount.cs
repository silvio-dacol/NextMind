using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//When a new scene is loaded, the selectionCount in ObjectSelectionTriggered is reset to zero

//Attach this script to the task buttons and add the Method to the OnClick() event

public class ResetSelectionCount : MonoBehaviour
{
    public void ResetTheCount()
    {
        CheckSelectionCorrectness checkSelectionCorrectness = FindObjectOfType<CheckSelectionCorrectness>();

        checkSelectionCorrectness.selectionCount = 0;
    }
}
