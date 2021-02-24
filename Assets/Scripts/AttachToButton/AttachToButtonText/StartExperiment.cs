using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Attach this script to the Text object of the Button "Start Experiment"

//This script will display the timer from 3 to 0 to make the user aware that the experiment is starting
//The button will then destroy

public class StartExperiment : MonoBehaviour
{
    //Seconds that Unity waits before doing again what is specified in the method
    private float secondsToWait = 1.0f;

    //I start the Coroutine whenever the "StartExperiment" Button is clicked
    public void CountingTimer()
    {
        StartCoroutine(WaitAndTimer(secondsToWait));
    }

    IEnumerator WaitAndTimer(float waitTime)
    {
        gameObject.GetComponent<TMP_Text>().fontSize = 0.5f;

        //The for statement is needed because I need to do 4 times the same action
        for (int i = 3; i >= 0; i--)
        {
            //I change the text inside the button relative to the variable "i"
            gameObject.GetComponent<TMP_Text>().text = i.ToString();

            //This line of code make unity wait for the amount of time specified in waitTime variable
            yield return new WaitForSeconds(waitTime);
        }

        //I hide the button after the time is passed
        gameObject.transform.parent.transform.localScale = new Vector3(0, 0, 0);
    }
}