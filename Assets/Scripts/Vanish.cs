using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanish : MonoBehaviour
{
    void Destroy()
    {
        Destroy(gameObject);
    }
}