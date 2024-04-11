using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelNumber;

    private void Update()
    {
        if (GameManager.Instance.CurrentLevel >= levelNumber) 
        {
            gameObject.SetActive(true); 
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNumber);
        }
    }
}
