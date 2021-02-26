using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulVariables : MonoBehaviour
{
    //SelectionCount
    [Tooltip("How many objects do you want the user to select in the scene?")]
    public int numberOfSelections = 10;
    [Tooltip("How many objects has already been hit for that specific experiment")]
    public int selectionCount;

    //RandomNumber for Object Selection
    [Tooltip("The random number for that turn")]
    public int randomNumber;

    //File name where to store the data
    [Tooltip("File where the data are stored for the single person")]
    public string filePath = "";

    //Accuracy Count
    [Tooltip("How many objects did the user hit well?")]
    public int rightObjectSelection;
    [Tooltip("How many objects did the user hit wrong?")]
    public int wrongObjectSelection;

    //Time Count
    [Tooltip("How much time did the user take in the scene?")]
    public float totalTimeInTheScene;
    [Tooltip("How much time did the user take to do the single selection tasks? (Max 40 in a scene)")]
    public float[] timeOfSingleSelection = new float[40];

    void Start()
    {
        //Just initialising my array of the split time
        timeOfSingleSelection = new float[40];

        //I don't want this gameObject to be destroyed when changing scenes because I need it for the length of the experiment
        DontDestroyOnLoad(gameObject);
    }
}
