using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public int CurrentCutscene;
    public int ThisLevel;
    public int CurrentLevel;

    public int CollectiblesCollected;

    public int[] LevelScores = { 0, 0, 0, 0, 0, 0 };

    public List<string> EnemyNames = new List<string>();
    public List<Material> EnemyImages = new List<Material>();

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        CurrentCutscene = 0;
        ThisLevel = 0;
        CurrentLevel = 1;

        CollectiblesCollected = 0;
    }
}
