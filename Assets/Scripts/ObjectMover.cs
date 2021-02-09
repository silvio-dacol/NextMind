using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    //I get the transform of the participant when the scene opens
    private Transform observerTransform;

    [Tooltip("Specify the distance of the objects from the user. Be sure that the room is larger than this")]
    public float offset;
    
    void Start()
    {
        gameObject.transform.position = Camera.main.GetComponent<Transform>().position;

        gameObject.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, offset);
        gameObject.transform.GetChild(1).transform.localPosition = new Vector3(offset, 0, 0);
        gameObject.transform.GetChild(2).transform.localPosition = new Vector3(-offset, 0, 0);
    }
}
