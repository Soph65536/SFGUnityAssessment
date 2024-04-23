using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Clip;

    // Start is called before the first frame update
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.PlayOneShot(Clip, 1f);

        StartCoroutine("WaitForDeath");
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
