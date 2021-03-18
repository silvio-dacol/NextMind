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
    string boxOrNoBox;
    string accuracyOfSingleSelection;
    string matrixCase;
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
            boxOrNoBox = String.Join("    ", usefulVariables.boxOrNoBox);
            accuracyOfSingleSelection = String.Join("    ", usefulVariables.accuracyOfSingleSelection);
            matrixCase = String.Join("    ", usefulVariables.matrixCase);
            timeOfSingleSelection = String.Join("    ", usefulVariables.timeOfSingleSelection);

            File.AppendAllText(usefulVariables.filePath, "" +
                
                gameObject.scene.name + "\n\n" +
                
                "Device:                           " + usefulVariables.device + "\n" +
                "Number of Selections:             " + usefulVariables.numberOfSelections + "\n\n" +
                
                "Accuracy:\n" + 
                "Right Selections:                 " + usefulVariables.rightObjectSelection + "\n" +
                "Wrong Selections:                 " + usefulVariables.wrongObjectSelection + "\n" +
                "Signal is present? (Yellow Box)   " + boxOrNoBox +"\n" +
                "Right or Wrong:                   " + accuracyOfSingleSelection + "\n" +
                "Signal Detection Theory Case:     " + matrixCase + "\n\n" +
                
                "Time:\n" +
                "Total Time in the Scene:          " + usefulVariables.totalTimeInTheScene + "\n" +
                "Time per Selection:               " + timeOfSingleSelection.ToString() + "\n\n\n");


            //Now I just Load the MainMenu scene again
            //I get and store all the loaded scenes in an array
            int countLoaded = SceneManager.sceneCount;
            Scene[] loadedScenes = new Scene[countLoaded];

            for (int i = 0; i < countLoaded; i++)
            {
                loadedScenes[i] = SceneManager.GetSceneAt(i);
            }

            //I unload the loaded scenes except the General one (which contains the essential things)
            for (int i = 0; i < countLoaded; i++)
            {
                if (loadedScenes[i].name != "General")
                {
                    SceneManager.UnloadSceneAsync(loadedScenes[i].name);
                }
            }

            //I load the scene relative to that specific task button
            SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);

            exit = 1;
        }
    }
}
