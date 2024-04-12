using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("WaitForDeath");
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
