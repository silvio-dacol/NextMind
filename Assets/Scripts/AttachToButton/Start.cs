using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the "Start" OnClick() event

public class Start : MonoBehaviour
{
    //This method creates a Random Number which will be assigned to the first element in the scene
    public void SwitchOnSelectionElements()
    {
        StartCoroutine(Wait(4.0f));

        StartCoroutine(AllObjectBlinking(0.5f));
    }

    IEnumerator Wait(float waitTime)
    {        
        //I get the ObjectContainer game object so that I'm able to count how many child it has
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        yield return new WaitForSeconds(waitTime);

        //I get the UsefulVariables script (it contains all the variable needed to be stored)
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I get the RandomNumberGenerator script
        RandomNumberGenerator randomNumberGenerator = GameObject.Find("RandomNumberGenerator").GetComponent<RandomNumberGenerator>();
        randomNumberGenerator.RandomNumber();

        //I get the ToggleCollector of the SceneMenu and I deactivate it
        GameObject.Find("ToggleCollector").GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);

        //If the usefulVariables.boxOrNoBox == 1 activate the box over the element (Just in that case)
        if(usefulVariables.boxOrNoBox[0] == 1)
        {
            //Activate the one I need respect to the new random object so that the user can understand which one he could select
            objectContainer.GetChild(usefulVariables.randomNumber).transform.Find("RandomIdentifier").gameObject.SetActive(true);
        }
    }

    IEnumerator AllObjectBlinking(float blinkTime)
    {
        //I get the objectContainer Game Object with all the selectables inside
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I get the reduceObjectDimension localScale variable
        float localScale = GameObject.Find("ReduceObjectDimension").GetComponent<ReduceObjectDimension>().localScale;

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(localScale, localScale, localScale);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(localScale, localScale, localScale);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(localScale, localScale, localScale);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(blinkTime);

        for (int i = 0; i < objectContainer.childCount - 1; i++)
        {
            objectContainer.GetChild(i).transform.localScale = new Vector3(localScale, localScale, localScale);
        }
        yield return new WaitForSeconds(blinkTime);
    }
}
