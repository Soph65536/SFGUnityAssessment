using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Collectible;
    private bool isSpawning = false;

    private float SpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay = Random.Range(0f, 60f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isSpawning)
        {
            StartCoroutine("SpawnCollectible");
        }
    }

    IEnumerator SpawnCollectible()
    {
        isSpawning = true;

        yield return new WaitForSeconds(SpawnDelay);

        GameObject newCollectible = Instantiate(Collectible);
        newCollectible.transform.position = this.transform.position;

        isSpawning = false;
    }
}
