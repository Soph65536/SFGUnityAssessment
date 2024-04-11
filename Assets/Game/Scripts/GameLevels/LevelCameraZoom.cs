using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraZoom : MonoBehaviour
{
    const int NonZoomPos = 0;
    const int ZoomPos = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.forward * ZoomPos;
        }
        else
        {
            transform.localPosition = Vector3.forward * NonZoomPos;
        }
    }
}
