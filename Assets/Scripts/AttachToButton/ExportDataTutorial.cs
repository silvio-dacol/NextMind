using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

// Script to be attached to the MainMenu button in the scenes

public class ExportDataTutorial : MonoBehaviour
{
    UsefulVariables usefulVariables;

    private void Start()
    {
        //I get the usefulVariables script (it contains all the variable needed to be stored)
        usefulVariables = FindObjectOfType<UsefulVariables>();
    }

    public void SaveTutorialData()
    {
        File.AppendAllText(usefulVariables.filePath, "" +

        gameObject.scene.name + "\n\n" +

        "Total Time in the Tutorial:          " + usefulVariables.totalTimeInTheScene + "\n\n\n");
    }
}
