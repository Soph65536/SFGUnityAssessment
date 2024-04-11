using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health;

    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            GameManager.Instance.Enemies.Add(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>() != null)
        {
            Health -= 1;
        }
    }
}
