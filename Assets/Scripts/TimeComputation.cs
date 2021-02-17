using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

public class TimeComputation : MonoBehaviour
{
    void Update()
    {
        //if NeuroTag is enabled, make time starting from the focus
        if(gameObject.GetComponent<NeuroTag>().enabled == true)
        {

        }

        //if Interactable is enabled, make time starting from hand 
        else if(gameObject.GetComponent<Interactable>().enabled == true)
        {

        }

        //else don't do anything
        else
        {
            Debug.Log("Both NeuroTag and Interactable are disabled");
        }
    }
}