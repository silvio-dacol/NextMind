using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionColour : MonoBehaviour
{
    private void OnEnable()
    {
        Selection();
    }

    private void OnDisable()
    {
        Deselection();
    }

    private void Selection()
    {
        //Get the Renderer of the parent
        Renderer materialRenderer = gameObject.transform.parent.gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color"
        materialRenderer.material.SetColor("_Color", new Color32(175, 175, 175, 255));
    }

    private void Deselection()
    {
        //Get the Renderer of the parent
        Renderer materialRenderer = gameObject.transform.parent.gameObject.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color"
        materialRenderer.material.SetColor("_Color", new Color32(41, 41, 41, 255));
    }
}
