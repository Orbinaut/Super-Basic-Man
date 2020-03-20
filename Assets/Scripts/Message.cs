using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}