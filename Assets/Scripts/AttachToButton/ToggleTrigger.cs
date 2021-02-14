using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

//Script to be attached to NextMind and HoloLens buttons to activate or deactivate the respective objects components

public class ToggleTrigger : MonoBehaviour
{
    private Transform objectContainer;

    public void HoloLensTriggerOn()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for(int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<Interactable>().enabled = true;
        }
    }

    public void HoloLensTriggerOff()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<Interactable>().enabled = false;
        }
    }

    public void NextMindTriggerOn()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<NeuroTag>().enabled = true;
        }
    }

    public void NextMindTriggerOff()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<NeuroTag>().enabled = false;
        }
    }
}

