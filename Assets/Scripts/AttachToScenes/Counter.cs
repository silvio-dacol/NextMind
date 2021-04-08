using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Script to be attached to the Counter of the CounterCanvas

public class Counter : MonoBehaviour
{
    TMP_Text counter;
    UsefulVariables usefulVariables;

    void Start()
    {
        //I get the component and then I'll change the text in the Update
        counter = gameObject.GetComponent<TMP_Text>();

        //I get the usefulVariables script (it contains all the variable needed to be stored)
        usefulVariables = FindObjectOfType<UsefulVariables>();

        //I change the text here based on the useful variables script
        counter.text = usefulVariables.selectionCount + " / " + usefulVariables.numberOfSelections;
    }

    void Update()
    {
        //I change the text here based on the useful variables script
        counter.text = usefulVariables.selectionCount + " / " + usefulVariables.numberOfSelections;
    }
}
