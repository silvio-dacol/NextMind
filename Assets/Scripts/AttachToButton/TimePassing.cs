using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePassing : MonoBehaviour
{
    //variable allowing me to enter the update function
    public bool trigger;

    //Define the usefulVariables class
    UsefulVariables usefulVariables;

    private void Start()
    {
        //Assign the value to trigger
        trigger = false;

        //Assign to the usefulVariables.totalTimeInTheScene the value corresponding to the time the button will disapear
        usefulVariables = FindObjectOfType<UsefulVariables>();
    }

    public void TotalTimeInTheScene()
    {
        //Variable allowing to enter the if statement in the Upload method
        trigger = true;

        //Assign to the usefulVariables.totalTimeInTheScene the value corresponding to the time the button will disapear
        usefulVariables.totalTimeInTheScene = -4.0f;
    }

    private void Update()
    {
        //If I have pressed the button, enter here and stay until selectionCount is still under numberOfSelections
        if (trigger == true && usefulVariables.selectionCount < usefulVariables.numberOfSelections)
        {
            usefulVariables.totalTimeInTheScene = usefulVariables.totalTimeInTheScene + Time.deltaTime;
        }
    }
}
