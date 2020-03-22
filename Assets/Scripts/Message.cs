using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            gameObject.SetActive(false);
        }
    }
}