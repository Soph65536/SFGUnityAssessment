using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraMovement : MonoBehaviour
{
    const float maxRotation = 30;

    // Start is called before the first frame update
    void Start()
    {
        //set rotation to none
        transform.localEulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate to look where mouse does but clamped to maxRotation
    }
}
