using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyObject;
    private bool isSpawning = false;

    private float SpawnDelay;
    private int EnemiesHealth;

    private void Awake()
    {
        switch (GameManager.Instance.ThisLevel)
        {
            case 0:
                SpawnDelay = 5;
                EnemiesHealth = 1;
                break;
            case 1:
                SpawnDelay = 4;
                EnemiesHealth = 2;
                break;
            case 2:
                SpawnDelay = 5;
                EnemiesHealth = 3;
                break;
            case 3:
                SpawnDelay = 6;
                EnemiesHealth = 4;
                break;
            case 4:
                SpawnDelay = 8;
                EnemiesHealth = 5;
                break;
            case 5:
                SpawnDelay = 10;
                EnemiesHealth = 10;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isSpawning)
        {
            StartCoroutine("SpawnEnemy");
        }
    }

    IEnumerator SpawnEnemy()
    {
        isSpawning = true;

        yield return new WaitForSeconds(SpawnDelay);

        GameObject newEnemy = Instantiate(EnemyObject);
        newEnemy.GetComponent<EnemyHealth>().Health = Random.Range(EnemiesHealth, EnemiesHealth + 1);

        isSpawning = false;
    }
}
