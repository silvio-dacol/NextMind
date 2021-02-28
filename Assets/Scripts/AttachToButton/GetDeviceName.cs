using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;

//Script to be attached to the Button Toggle to get the device name in the general variables

public class GetDeviceName : MonoBehaviour
{
    UsefulVariables usefulVariables;

    void Start()
    {
        //I get the usefulVariables script (it contains all the variable needed to be stored)
        usefulVariables = FindObjectOfType<UsefulVariables>();
    }

    void Update()
    {
        //I get the device name when the participant has already done some selections
        if (usefulVariables.selectionCount == 5 && gameObject.GetComponent<Interactable>().IsToggled)
        {
            usefulVariables.device = gameObject.transform.Find("Text").GetComponent<TMP_Text>().text;
        }
    }
}
