using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float translateSpeed;
    //Define the speed at which the object moves.

    public float rotationSpeed;
    //Define the speed at which the object rotates.

    private float fixedY;

    private void Start()
    {
        fixedY = gameObject.transform.position.y;
    }

    void Update()
    {
        //Translation
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * translateSpeed * Time.deltaTime, Space.Self);

        //Rotation
        float pitch = Input.GetAxis("Mouse Y") * -1f * rotationSpeed;
        transform.Rotate(pitch * Vector3.right, Space.Self);
        float yaw = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(yaw * Vector3.up, Space.World);

        //Keep y position at the original one
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, fixedY, gameObject.transform.position.z);
    }
}
