using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject message;
    public GameObject keyMessage;
    public GameObject icon;

    private CollectStuff collectScript;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            collectScript = playerObject.GetComponent<CollectStuff>();
        }
        if (collectScript == null)
        {
            Debug.Log("Cannot find 'CollectStuff' script");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (collectScript.hasKey)
            {
                message.gameObject.SetActive(true);
                icon.gameObject.SetActive(true);
                collectScript.hasBouncer = true;
                collectScript.hasArrow = true;
                collectScript.hasGun = true;
            }
            else
            {
                keyMessage.gameObject.SetActive(true);
            }
        }
    }
}