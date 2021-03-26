using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

//Attach this script to the objects in the task scene 

public class LimitTimeSelection : MonoBehaviour
{
    //Define the usefulVariables class
    private UsefulVariables usefulVariables;

    //Time limit of 60 seconds (gives pressure to the user)
    public float timeLimit = 60f;

    void Start()
    {
        //Assign to the usefulVariables.totalTimeInTheScene the value corresponding to the time the button will disapear
        usefulVariables = FindObjectOfType<UsefulVariables>();
    }

    void Update()
    {
        int i = usefulVariables.selectionCount;

        float sumOfTheArrayTimes = 0f;

        for (int t = i - 1; t >= 0; t--)
        {
            sumOfTheArrayTimes = sumOfTheArrayTimes + usefulVariables.timeOfSingleSelection[t];
        }

        if (usefulVariables.totalTimeInTheScene - sumOfTheArrayTimes > timeLimit)
        {
            gameObject.GetComponent<Interactable>().OnClick.Invoke();
        }
    }
}
