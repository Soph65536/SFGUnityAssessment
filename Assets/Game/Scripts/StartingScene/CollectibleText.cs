using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMesh>().text = "Collectibles Collected\n" + GameManager.Instance.CollectiblesCollected.ToString();
    }
}
