using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimerAndText : MonoBehaviour
{
    private float gameTimer = 60;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("CountDownTimer"); 
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text  = "Time Left: " + gameTimer.ToString();
        ScoreText.text = GameManager.Instance.LevelScores[GameManager.Instance.ThisLevel].ToString();
    }

    private IEnumerator CountDownTimer()
    {
        while(gameTimer > 0){
            yield return new WaitForSeconds(1);
            gameTimer -= 1;
        }
        //increment current level and load starting scene
        GameManager.Instance.CurrentLevel ++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
