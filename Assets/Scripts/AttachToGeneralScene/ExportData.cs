using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ExportData : MonoBehaviour
{
    public void CreateFile()
    {
        // Specify a name for your folder.
        string pathString = Application.dataPath + "/ExperimentData";

        //If the directory still not exist, create it
        if(!File.Exists(pathString))
        {
            System.IO.Directory.CreateDirectory(pathString);
        }

        // Create a file name for the file you want to create.
        string fileName = "Ciccio Benzina.txt";

        // Use Combine to add the file name to the path.
        pathString = System.IO.Path.Combine(pathString, fileName);

        //Create the actual file and control it doesn't exist
        if(!File.Exists(pathString))
        {
            //File.WriteAllText will rewrite all the file if you let it do that
            File.WriteAllText(pathString, "" +
                "Date: " + DateTime.Now + "\n" +
                "Name: " + "\n" +
                "Age: " + "\n" +
                "Gender: " + "\n" +
                "\n" + 
                "\n");
        }
    }
}
