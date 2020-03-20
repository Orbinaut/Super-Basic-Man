using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public GameObject[] items;

    private int healthPoints;
    public int maxHealth;
    public int minHealth;

    Renderer rend;
    Color color;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;
        healthPoints = Random.Range(minHealth, maxHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            healthPoints--;
            StartCoroutine("HurtAnimation");

            if (healthPoints <= 0)
            {
                GameObject item = items[Random.Range(0, items.Length)];
                Instantiate(item, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator HurtAnimation()
    {
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(0.05f);
        color.a = 1f;
        rend.material.color = color;
    }
}