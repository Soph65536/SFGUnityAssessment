using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowErrorScreen : MonoBehaviour
{
    public GameObject errorScreen;

    // Start is called before the first frame update
    void Start()
    {
        errorScreen = GameObject.FindGameObjectWithTag("ErrorScreen");
        errorScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("ErrorScreen");
    }

    IEnumerator ErrorScreen(){
        errorScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
