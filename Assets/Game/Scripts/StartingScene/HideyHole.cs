using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideyHole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GameManager.Instance.CurrentLevel);
        }
    }
}
