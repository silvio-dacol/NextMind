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

    //Used device for that experiment
    [Tooltip("Which of the two devices is used in the current experiment")]
    public string device = "";

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
    [Tooltip("How many object were right selected and how many wrong selected?")] //Returns: 1 (right) and 0 (wrong)
    public int[] accuracyOfSingleSelection = new int[0];

    //Signal Detection Theory
    [Tooltip("Is there the Random Identifier over an object? 0 (No), 1 (Yes)")]
    public int[] boxOrNoBox = new int[0];
    [Tooltip("In which case of the 4x4 matrix am I? First number is the matrix row, Second number is the matrix column (11, 12, 21, 22")]
    public int[] matrixCase = new int[0];

    //Time Count
    [Tooltip("How much time did the user take in the scene?")]
    public float totalTimeInTheScene;
    [Tooltip("How much time did the user take to do the single selection tasks?")]
    public float[] timeOfSingleSelection = new float[0];

    void Start()
    {
        //Just initialising my array of the accuracy
        accuracyOfSingleSelection = new int[numberOfSelections];

        //Just initialising my array of the split time
        timeOfSingleSelection = new float[numberOfSelections];

        //Signal Detection Theory Part
        boxOrNoBox = new int[numberOfSelections];
        matrixCase = new int[numberOfSelections];

        //I don't want this gameObject to be destroyed when changing scenes because I need it for the length of the experiment
        DontDestroyOnLoad(gameObject);
    }
}
