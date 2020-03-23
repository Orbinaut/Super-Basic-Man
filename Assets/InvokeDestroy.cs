using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeDestroy : MonoBehaviour
{    
    private void OnEnable()
    {
        Invoke("Destroy", 0.75f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}