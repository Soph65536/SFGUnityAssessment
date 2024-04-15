using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEndingObjects : MonoBehaviour
{
    const float spacing = 5;
    public GameObject TrenchGremlin;
    public GameObject endingObject;
    public void CreateObjects()
    {
        bool leftright = false;
        for (int i = 0; i < GameManager.Instance.EnemyNames.Count; i++)
        {
            //create clone
            GameObject clonedGremlin = Instantiate(TrenchGremlin, transform.position, Quaternion.identity);
            //set clone position
            clonedGremlin.GetComponent<EnemyMovement>().enabled = false;
            clonedGremlin.transform.position = transform.position; 
            //set clone name and material
            clonedGremlin.GetComponent<EnemyHealth>().Name = GameManager.Instance.EnemyNames[i];
            clonedGremlin.GetComponent<Renderer>().material = GameManager.Instance.EnemyImages[i];

            if (leftright)
            {
                transform.position += Vector3.forward * spacing;
            }
            else
            {
                transform.position -= Vector3.forward * spacing;
            }

            transform.position += Vector3.left;
            leftright = !leftright;
        }

        if (leftright)
        {
            transform.position += Vector3.forward * spacing/2;
        }
        else
        {
            transform.position -= Vector3.forward * spacing/2;
        }

        Instantiate(endingObject, transform.position, Quaternion.identity);
    }
}
