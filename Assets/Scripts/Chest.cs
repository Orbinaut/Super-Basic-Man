using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject message;
    public GameObject icon;
    public GameObject keyMessage;
    public GameObject keyIcon;
    public GameObject openChest;

    public AudioSource keyNeeded;

    public int keyNumber;

    private CollectStuff collectScript;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            collectScript = player.GetComponent<CollectStuff>();
        }
        if (collectScript == null)
        {
            Debug.Log("Can't find the 'CollectStuff' script");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (collectScript.hasKey == keyNumber)
            {
                message.gameObject.SetActive(true);
                icon.gameObject.SetActive(true);
                collectScript.weaponLevel = keyNumber;
                keyIcon.gameObject.SetActive(false);
                Instantiate(openChest, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                keyMessage.gameObject.SetActive(true);
                keyNeeded.Play();
            }
        }
    }
}