using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Arrow") || Input.GetButtonDown("Bouncer") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Shoot"))
        {
            gameObject.SetActive(false);
        }
    }
}