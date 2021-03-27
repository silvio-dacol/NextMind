using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class CreateParticipantFile : MonoBehaviour
{
    [Tooltip("Check this if you're testing the application in simulation mode on PC\n" +
        "Uncheck if you're testing on HoloLens")]
    public bool isItSimulationMode = true;

    //Method to Create the file I need at the OnClick() event of the StartExperiment button
    public void CreateFile()
    {
        string pathString = "";

        //Create a random file.txt name for the file you want to create.
        string fileName = randomFileName();

        //When I want to run the application on the pc simulation
        if (isItSimulationMode == true)
        {
            //Specify a name for your folder.
            pathString = Application.dataPath + "/ExperimentData";

            //If the directory still not exist, create it
            if(!File.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }

            //Use Combine to add the file name to the path.
            pathString = Path.Combine(pathString, fileName);
        }

        //When I want to run the Application on the HoloLens
        else if (isItSimulationMode == false)
        {
            //Use Combine to add the file name to the path.
            pathString = Path.Combine(Application.persistentDataPath, fileName);
        }

        //Store the file name (string) in the UsefulVariable script container
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();
        usefulVariables.filePath = pathString;

        //Create the actual file and control it doesn't exist
        if (!File.Exists(pathString))
        {
            //File.WriteAllText will rewrite all the file if you let it do that
            File.WriteAllText(pathString, "" +
                "Date: " + DateTime.Now + "\n" +
                "Name: " + "\n" +
                "Age: " + "\n" +
                "Gender: " + "\n\n\n");
        }
    }

    //Method to create a random file.txt name
    private string randomFileName()
    {
        //Different characters that can be used in the name
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        //Array un which my name will be stored
        char[] stringChars = new char[8];

        //I don't know what is this
        var random = new System.Random();

        //Where my word will be stored
        string finalString;

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        finalString = new String(stringChars);
        finalString = finalString + ".txt";

        return finalString;
    }
}
