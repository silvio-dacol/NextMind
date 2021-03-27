using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to be attached to the different objects in the scene

//Remember to put the NoBoxObject at the last place of the children

public class ObjectSelectionTriggered : MonoBehaviour
{
    public void IncreaseSelectionCount()
    {
        //I get the usefulVariables script (it contains all the variable needed to be stored)
        UsefulVariables usefulVariables = FindObjectOfType<UsefulVariables>();

        //I get the objectContainer Game Object with all the selectables inside
        Transform objectContainer = GameObject.Find("ObjectContainer").transform;

        //I define the objectIndex in a variable
        int objectIndex;

        //I save the index of the clicked object right now 
        objectIndex = gameObject.transform.GetSiblingIndex();

        //I use a variable to exit to pass to the next selection task
        int exit = 0;




        //If there is a box over one element (Remember to put the NoBoxObject at the last place of the children)
        if (usefulVariables.boxOrNoBox[usefulVariables.selectionCount] == 1)
        {
            //I measure the accuracy of selection by comparing if the selected object child number correspond with the randomNumber

            //I store in the variable RandomNumber the new value
            int randomNumber = usefulVariables.randomNumber;



            //I compute the distance between the selected object and the one that must be selected so I can compare if the selected object is in the range
            float distanceBetweenObjects = Vector3.Distance(gameObject.transform.position, objectContainer.GetChild(randomNumber).transform.position);



            //If the selected object is the right one, increase the rightObjectSelection
            if(objectIndex == randomNumber)
            {
                //I'm in case 11 of the Signal Detection Theory Matrix
                usefulVariables.matrixCase[usefulVariables.selectionCount] = 11;

                //I increase of one the wight object selection variable
                usefulVariables.rightObjectSelection = usefulVariables.rightObjectSelection + 1;

                //I fill the corresponding array part with a 1 (right selection)
                usefulVariables.accuracyOfSingleSelection[usefulVariables.selectionCount] = 1;

                //I exit from the current selection task
                exit = 1;
            }

            //If the selected object is the wrong one and it is within the 2 meters sphere, increase the wrongObjectSelection
            else if(objectIndex != randomNumber && distanceBetweenObjects < 2)
            {
                //I'm in case 21 of the Signal Detection Theory Matrix
                usefulVariables.matrixCase[usefulVariables.selectionCount] = 21;

                usefulVariables.wrongObjectSelection = usefulVariables.wrongObjectSelection + 1;

                usefulVariables.accuracyOfSingleSelection[usefulVariables.selectionCount] = 0;

                //I exit from the current selection task
                exit = 1;
            }
            
            



            //When the comparison finished, I call again the RandomNumberGenerator to obtain a new randomNumber
            if(exit == 1)
            {
                RandomNumberGenerator randomNumberGenerator = FindObjectOfType<RandomNumberGenerator>();

                randomNumberGenerator.RandomNumber();

                //If the random number is equal to the previous one, do it again until is different
                while(randomNumber == usefulVariables.randomNumber)
                {
                    randomNumberGenerator.RandomNumber();
                }
            }
        }






        //If there is NOT a box over one element (Remember to put the NoBoxObject at the last place of the children)
        else if (usefulVariables.boxOrNoBox[usefulVariables.selectionCount] == 0)
        {
            //I measure the accuracy of selection by comparing if the selected object child number correspond with the randomNumber

            //I store in the variable RandomNumber the new value correspondent to the NoBoxObject (Red Cube)
            int randomNumber = objectContainer.childCount - 1;



            //I compute the distance between the selected object and the one that must be selected so I can compare if the selected object is in the range
            float distanceBetweenObjects = Vector3.Distance(gameObject.transform.position, objectContainer.GetChild(randomNumber).transform.position);



            //If the selected object is the right one, increase the rightObjectSelection
            if (objectIndex == randomNumber)
            {
                //I'm in case 22 of the Signal Detection Theory Matrix
                usefulVariables.matrixCase[usefulVariables.selectionCount] = 22;

                //I increase of one the wight object selection variable
                usefulVariables.rightObjectSelection = usefulVariables.rightObjectSelection + 1;

                //I fill the corresponding array part with a 1 (right selection)
                usefulVariables.accuracyOfSingleSelection[usefulVariables.selectionCount] = 1;

                //I exit from the current selection task
                exit = 1;
            }

            //If the selected object is the wrong one, increase the wrongObjectSelection
            else if (objectIndex != randomNumber && distanceBetweenObjects < 2)
            {
                //I'm in case 12 of the Signal Detection Theory Matrix
                usefulVariables.matrixCase[usefulVariables.selectionCount] = 12;

                usefulVariables.wrongObjectSelection = usefulVariables.wrongObjectSelection + 1;

                usefulVariables.accuracyOfSingleSelection[usefulVariables.selectionCount] = 0;

                //I exit from the current selection task
                exit = 1;
            }
        }


        //I enter here just if the exit variable is 1
        if (exit == 1)
        {
            //Deactivate all the identifiers
            for (int i = 0; i < objectContainer.childCount; i++)
            {
                objectContainer.GetChild(i).transform.Find("RandomIdentifier").gameObject.SetActive(false);
            }



            //I get the SelectionSound script
            SelectionSound selectionSound = FindObjectOfType<SelectionSound>();
            //I play the sound everytime I select an object
            selectionSound.Play();



            //I make the object blinking when selected so the user can understand when he has selected something
            StartCoroutine(Blinker(0.3f));



            //I increase the counter of the number of times an object is selected
            usefulVariables.selectionCount = usefulVariables.selectionCount + 1;



            //Check this just for the first selection (if I don't add this, it gives an Exception)
            if (usefulVariables.selectionCount < usefulVariables.numberOfSelections)
            {
                //Now I activate the randomIdentifier of the new object and deactivate all the others
                //Deactivate all the identifiers
                for (int i = 0; i < objectContainer.childCount; i++)
                {
                    objectContainer.GetChild(i).transform.Find("RandomIdentifier").gameObject.SetActive(false);
                }

                //If the usefulVariables.boxOrNoBox == 1 activate the box over the element (Just in that case)
                if (usefulVariables.boxOrNoBox[usefulVariables.selectionCount] == 1)
                {
                    //Activate the one I need respect to the new random object so that the user can understand which one he could select
                    objectContainer.GetChild(usefulVariables.randomNumber).transform.Find("RandomIdentifier").gameObject.SetActive(true);
                }
            }
        }
    }



    //This IEnumerator makes the object blinking when selected
    IEnumerator Blinker(float blinkTime)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(blinkTime);

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(blinkTime);

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(blinkTime);

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(blinkTime);

        gameObject.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(blinkTime);

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(blinkTime);
    }
}
