using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInTime : MonoBehaviour
{
    private int rotationSpeed = 35;

    void Update()
    {
        //I make the RandomIdentifier rotating over the object
        gameObject.transform.Rotate(gameObject.GetComponentInParent<Transform>().up * rotationSpeed * Time.deltaTime);
    }
}
