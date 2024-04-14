using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int levelNumber;

    public AudioSource AudioSource;
    public AudioClip loadLevel;

    private void Start()
    {
        //set audio source
        AudioSource = GetComponent<AudioSource>();
        //set score text to score of level number
        GetComponentInChildren<TextMesh>().text = "Score\n" + GameManager.Instance.LevelScores[levelNumber - 1].ToString();

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            StartCoroutine("EnterLevel");
        }
    }

    private IEnumerator EnterLevel()
    {
        AudioSource.PlayOneShot(loadLevel, 0.3f);
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.ThisLevel = levelNumber - 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
