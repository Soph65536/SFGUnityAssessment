using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelNumber;

    private void Start()
    {
        //set score text to score of level number
        GetComponentInChildren<TextMesh>().text = "Score\n" + GameManager.Instance.LevelScores[levelNumber - 1].ToString();
    }

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
            GameManager.Instance.ThisLevel = levelNumber - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNumber);
        }
    }
}
