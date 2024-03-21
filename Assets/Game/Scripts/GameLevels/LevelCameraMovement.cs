using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraMovement : MonoBehaviour
{
    const float maxRotation = 30;
    const float turnMultiplier = 1;
    const float slideMultiplier = 2;

    public float xRotation = 0;
    public float yRotation = 0;

    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set rotation to none
        transform.localEulerAngles = Vector3.zero;

        //set starting position
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate to look where mouse does but clamped to maxRotation

        //set rotation angles
        xRotation += Input.GetAxis("Mouse X");
        xRotation = Mathf.Clamp(xRotation, -maxRotation, maxRotation);

        yRotation -= Input.GetAxis("Mouse Y");
        yRotation = Mathf.Clamp(yRotation, -maxRotation, maxRotation);

        //update transform angle and position
        transform.localEulerAngles = new Vector3(yRotation, xRotation, -Input.GetAxis("Horizontal") * turnMultiplier);

        //offset starting position by horizontal input
        transform.position = startingPosition + (Vector3.right * Input.GetAxis("Horizontal") * slideMultiplier);
    }
}
