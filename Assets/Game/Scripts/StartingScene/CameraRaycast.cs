using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    const float interactrange = 7.5f;

    public TextMeshProUGUI RayCastText;

    // Update is called once per frame
    void FixedUpdate()
    {
        CastRay();
    }

    void CastRay(){
        //reset text
        RayCastText.text = string.Empty;

        //RayCastHit contains information about whatever object the raycast is detecting
        RaycastHit raycastobjinfo = new RaycastHit();
        //hit determines if the raycast has hit an object
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastobjinfo, interactrange);
        if(hit){
            GameObject hitObject = raycastobjinfo.transform.gameObject;

            //display name on screen if is a levelloader
            if(hitObject.GetComponent<LevelLoader>() != null) 
            {
                RayCastText.text = hitObject.name;
            }

            //interact if press e
            if (Input.GetKey(KeyCode.E))
            {
                hitObject.GetComponent<IInteractable>().BeginInteract();
            }
        }
    }
}
