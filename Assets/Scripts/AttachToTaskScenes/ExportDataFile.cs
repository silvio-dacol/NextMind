using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ExportDataFile : MonoBehaviour
{
    UsefulVariables usefulVariables;
    int exit;
    string accuracyOfSingleSelection;
    string timeOfSingleSelection;

    private void Start()
    {
        //I get the usefulVariables script (it contains all the variable needed to be stored)
        usefulVariables = FindObjectOfType<UsefulVariables>();

        //I set the exit variable to 0
        exit = 0;
    }

    private void Update()
    {
        if (usefulVariables.selectionCount == usefulVariables.numberOfSelections && exit != 1)
        {
            //I create a string which can contain inside all the components of my arrays
            accuracyOfSingleSelection = String.Join("    ", usefulVariables.accuracyOfSingleSelection);
            timeOfSingleSelection = String.Join("    ", usefulVariables.timeOfSingleSelection);

            File.AppendAllText(usefulVariables.filePath, "" +
                
                gameObject.scene.name + "\n\n" +
                
                "Device:                      " + usefulVariables.device + "\n" +
                "Number of Selections:        " + usefulVariables.numberOfSelections + "\n\n" +
                
                "Accuracy:\n" + 
                "Right Selections:            " + usefulVariables.rightObjectSelection + "\n" +
                "Wrong Selections:            " + usefulVariables.wrongObjectSelection + "\n" +
                "Right or Wrong:              " + accuracyOfSingleSelection + "\n\n" +
                
                "Time:\n" +
                "Total Time in the Scene:     " + usefulVariables.totalTimeInTheScene + "\n" +
                "Time per Selection:          " + timeOfSingleSelection.ToString() + "\n\n");

            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
