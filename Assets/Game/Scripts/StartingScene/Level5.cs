using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour
{
    public int levelNumber;
    private void Start()
    {
        //display if level has been unlocked
        if (GameManager.Instance.CurrentLevel >= levelNumber)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
