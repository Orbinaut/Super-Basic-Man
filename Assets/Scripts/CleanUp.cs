using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public float time;

    void Start()
    {
        Invoke("KillOff", time);
    }

void KillOff()
    {
        Destroy(gameObject);
    }
}