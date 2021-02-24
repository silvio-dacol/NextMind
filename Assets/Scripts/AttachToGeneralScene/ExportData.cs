using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ExportData : MonoBehaviour
{
    //Method to Create the file I need at the OnClick() event of the StartExperiment button
    public void CreateFile()
    {
        //Specify a name for your folder.
        string pathString = Application.dataPath + "/ExperimentData";

        //If the directory still not exist, create it
        if(!File.Exists(pathString))
        {
            System.IO.Directory.CreateDirectory(pathString);
        }

        //Create a random file.txt name for the file you want to create.
        string fileName = randomFileName();

        //Use Combine to add the file name to the path.
        pathString = System.IO.Path.Combine(pathString, fileName);

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
                "Gender: " + "\n" +
                "\n");
        }
    }

    public void WriteDataOnFile()
    {

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
