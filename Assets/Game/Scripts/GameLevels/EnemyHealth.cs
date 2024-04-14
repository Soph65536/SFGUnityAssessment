using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    const float DeathTime = 2;

    public int Health;
    public AudioSource AudioSource;
    public AudioClip hitEnemy;
    public ParticleSystem DeathParticles;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        DeathParticles = GetComponentInChildren<ParticleSystem>();
        DeathParticles.Stop();
    }

    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            StartCoroutine("EnemyDeath");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>() != null)
        {
            //player hit sound and decrement health
            AudioSource.PlayOneShot(hitEnemy, 0.7f);
            Health --;
        }
    }

    private IEnumerator EnemyDeath()
    {
        //add object to enemies
        GameManager.Instance.Enemies.Add(gameObject);

        //disable mesh renderer so object isnt visible
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        //play particles and wait
        DeathParticles.Play();
        yield return new WaitForSeconds(DeathTime);

        //increment this level's score
        GameManager.Instance.LevelScores[GameManager.Instance.ThisLevel]++;

        //destroy object
        Destroy(gameObject);
    }
}
