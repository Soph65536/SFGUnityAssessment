using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFacePlayer : MonoBehaviour
{
    const int lookSpeed = 5;

    [SerializeField] private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //set player object
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //creates position to look at
        var lookPosition = playerObject.transform.position - transform.position;
        lookPosition.y = 0;
        //sets rotation to look at position
        var objectRotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, objectRotation, lookSpeed * Time.deltaTime); 
    }
}
