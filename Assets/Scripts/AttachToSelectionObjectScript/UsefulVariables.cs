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

    //RandomNumber
    [Tooltip("The random number for that turn")]
    public int randomNumber;

    //Accuracy Count
    [Tooltip("How many objects did the user hit well?")]
    public int rightObjectSelection;
    [Tooltip("How many objects did the user hit wrong?")]
    public int wrongObjectSelection;

    //Time Count
    [Tooltip("How much time did the user take in the scene?")]
    public float totalTimeInTheScene;
    [Tooltip("How much time did the user take to do a selection task?")]
    public float timeOfSingleSelection;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
