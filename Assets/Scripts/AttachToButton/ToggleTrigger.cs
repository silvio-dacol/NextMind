using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Microsoft.MixedReality.Toolkit.UI;
using NextMind.NeuroTags;

//Script to be attached to NextMind and HoloLens buttons to activate or deactivate the objects components Interactable and NeuroTag

public class ToggleTrigger : MonoBehaviour
{
    private Transform objectContainer;
    private GameObject holoLensToggle;
    private GameObject nextMindToggle;

    public void HoloLensTriggerOn()
    {
        //I get the ObjectContainer of all the objects of the scene
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for(int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);

            //I activate all the Interactable of the Objects
            child.GetComponent<Interactable>().enabled = true;

            //I deactivate all the NeuroTag of the Objects
            child.GetComponent<NeuroTag>().enabled = false;
        }

        //These statements are just for 
        nextMindToggle = GameObject.Find("NextMindToggle");
        nextMindToggle.GetComponent<Interactable>().IsToggled = false;
    }

    public void HoloLensTriggerOff()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<Interactable>().enabled = false;
            child.GetComponent<NeuroTag>().enabled = true;
        }

        nextMindToggle = GameObject.Find("NextMindToggle");
        nextMindToggle.GetComponent<Interactable>().IsToggled = true;
    }

    public void NextMindTriggerOn()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<Interactable>().enabled = false;
            child.GetComponent<NeuroTag>().enabled = true;
        }

        holoLensToggle = GameObject.Find("HoloLensToggle");
        holoLensToggle.GetComponent<Interactable>().IsToggled = false;
    }

    public void NextMindTriggerOff()
    {
        objectContainer = GameObject.Find("ObjectContainer").GetComponent<Transform>();

        Transform child;

        for (int i = 0; i < objectContainer.childCount; i++)
        {
            child = objectContainer.GetChild(i);
            child.GetComponent<Interactable>().enabled = true;
            child.GetComponent<NeuroTag>().enabled = false;
        }

        holoLensToggle = GameObject.Find("HoloLensToggle");
        holoLensToggle.GetComponent<Interactable>().IsToggled = true;
    }
}

