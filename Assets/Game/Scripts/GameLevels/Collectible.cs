using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    const float DeathTime = 2;

    public AudioSource AudioSource;
    public AudioClip hitCollectible;
    public ParticleSystem DeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        //set audio and particles
        AudioSource = GetComponent<AudioSource>();
        AudioSource.PlayOneShot(hitCollectible, 1);
        DeathParticles = GetComponentInChildren<ParticleSystem>();
        DeathParticles.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            StartCoroutine("CollectibleDeath");
        }
    }

    IEnumerator CollectibleDeath()
    {
        //disable mesh renderer so object isnt visible
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        //play particles and sound and wait
        DeathParticles.Play();
        AudioSource.PlayOneShot(hitCollectible, 1);
        yield return new WaitForSeconds(DeathTime);

        //find all enemies in scene and decrement health
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in Enemies)
        {
            enemy.GetComponent<EnemyHealth>().Health--;
        }

        //destroy object and inrease collectibles
        GameManager.Instance.CollectiblesCollected++;
        Destroy(gameObject);
    }
}
