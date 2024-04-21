using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!£$%^&*/?<>#~'@";
    const float DeathTime = 2;

    public int Health = 1;
    public AudioSource AudioSource;
    public AudioClip hitEnemy;
    public ParticleSystem DeathParticles;

    private bool died;

    public string Name;
    public Material Image;
    public TextMesh HealthText;

    private void Start()
    {
        //set and display name
        for (int i = 0; i < 5; i++)
        {
            Name += Characters[Random.Range(0, Characters.Length)];
        }
        Name += ".grog";
        GetComponentInChildren<TextMesh>().text = Name;

        //set health text
        HealthText.text = Health.ToString();

        //set random material
        int whichImage = Random.Range(0, Resources.LoadAll<Material>("GremlinMaterials").Length - 1);
        Image = Resources.LoadAll<Material>("GremlinMaterials")[whichImage];
        GetComponent<Renderer>().material = Image;

        //set audio and particles
        AudioSource = GetComponent<AudioSource>();
        DeathParticles = GetComponentInChildren<ParticleSystem>();
        DeathParticles.Stop();
    }

    private void FixedUpdate()
    {
        if (Health <= 0 && !died)
        {
            died = true;
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

            //set health text
            HealthText.text = Health.ToString();
        }
    }

    private IEnumerator EnemyDeath()
    {
        //disable mesh renderer so object isnt visible
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        //play particles and wait
        DeathParticles.Play();
        yield return new WaitForSeconds(DeathTime);

        //increment this level's score
        GameManager.Instance.LevelScores[GameManager.Instance.ThisLevel]++;

        //add object to enemies
        GameManager.Instance.EnemyNames.Add(Name);

        //add object to enemies
        GameManager.Instance.EnemyImages.Add(Image);

        //destroy object
        Destroy(gameObject);
    }
}
