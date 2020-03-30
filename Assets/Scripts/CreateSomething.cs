using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSomething : MonoBehaviour
{
    public GameObject something;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(something, transform.position, Quaternion.identity);
    }
}