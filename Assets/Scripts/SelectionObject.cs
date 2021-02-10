using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionObject : MonoBehaviour
{
    private int enter;
    private Transform parent;
    [Tooltip("Attach here the copy object")]
    public GameObject copy;
    [Tooltip("Attach here the transparent material you have created")]
    public Material transparentMaterial;

    private void Start()
    {
        enter = 1;

        gameObject.SetActive(false); //If the object is active I deactivate it because I then activate it with the OnTrigger() event of NextMind

        copy.SetActive(false); //Make sure the Copy is deativated
        copy.transform.localScale = new Vector3(gameObject.transform.localScale.x - 0.02f, gameObject.transform.localScale.y - 0.02f, gameObject.transform.localScale.z - 0.02f);
        copy.GetComponent<Renderer>().material = transparentMaterial;
        copy.AddComponent<Outline>();
        copy.GetComponent<Outline>().OutlineColor = Color.yellow;
        copy.GetComponent<Outline>().OutlineWidth = 10f;

        parent = transform.parent.parent; //This assignes to the variable parent the correspondent trasform


    }

    private void Update()
    {
        Debug.Log("The value of variable enter is " + enter);
        copy.transform.position = gameObject.transform.position;

        if (enter == 1)
        {
            copy.SetActive(true);

            enter = 2; //This value is set to false because, when I activate the object, it will set back to true

            gameObject.SetActive(false); //The SelectionObject script container is deactivated for the later new interaction (but variable enter is still and so I can use it to deactivate the selection)
        }

        else if (enter == 2)
        {
            copy.SetActive(false);

            enter = 1;

            gameObject.SetActive(false);
        }
    }
}