using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the objects (to use the method SingleSelectionTask)

public class TimeOfSelection : MonoBehaviour
{
    //Define the usefulVariables class
    UsefulVariables usefulVariables;

    void Start()
    {
        //Assign to the usefulVariables.totalTimeInTheScene the value corresponding to the time the button will disapear
        usefulVariables = FindObjectOfType<UsefulVariables>();
    }

    //Attach this method to the OnClick() HoloLens and to the OnTriggered() NextMind
    public void SingleSelectionTask()
    {
        int i = usefulVariables.selectionCount;

        //Just for the first selection task
        if(i == 0)
        {
            //I use 0 numbers after the comma
            usefulVariables.timeOfSingleSelection[i] = (float)System.Math.Round(usefulVariables.totalTimeInTheScene, 0);
        }

        //For all the other selection tasks I need to subtract the previous time to get the time of that specific selection
        else if(i > 0)
        {
            float sumOfTheArrayTimes = 0f;

            for (int t = i - 1; t >= 0; t--)
            {
                sumOfTheArrayTimes = sumOfTheArrayTimes + usefulVariables.timeOfSingleSelection[t];
            }

            //I use 0 numbers after the comma
            usefulVariables.timeOfSingleSelection[i] = (float)System.Math.Round(usefulVariables.totalTimeInTheScene - sumOfTheArrayTimes, 0);
        }
    }
}
