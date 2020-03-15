using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public GameObject[] items;

    public int healthPoints;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            healthPoints--;

            if (healthPoints <= 0)
            {
                GameObject item = items[Random.Range(0, items.Length)];
                Instantiate(item, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}