using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public GameObject myDoor;

    private Door doorScript;

    void Start()
    {
        doorScript = myDoor.GetComponent<Door>();

        if (doorScript == null)
        {
            Debug.Log("Can't find the 'Door' script");
        }
    }

    private void OnDestroy()
    {
        doorScript.open = true;
    }
}