using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyObject;
    private bool isSpawning = false;

    public float SpawnDelay;
    public int EnemiesHealth;

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
        newEnemy.GetComponent<EnemyHealth>().Health = Random.Range(EnemiesHealth - 1, EnemiesHealth + 1);

        isSpawning = false;
    }
}
