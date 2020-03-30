using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    #region Variables

    public GameObject message;
    public GameObject icon;
    public GameObject keyMessage;
    public GameObject keyIcon;
    public GameObject openChest;
    public GameObject gun;

    public int keyNumber;

    [FMODUnity.EventRef]
    public string keyNeededEvent;

    [FMODUnity.EventRef]
    public string achievementSoundEvent;

    private CollectStuff collectScript;

    private FMOD.Studio.EventInstance keyNeeded;

    #endregion

    void Start()
    {
        keyNeeded = FMODUnity.RuntimeManager.CreateInstance(keyNeededEvent);

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
                if (keyNumber == 1)
                {
                    gun.gameObject.SetActive(true);
                    collectScript.ammo = 25;
                }
            }
            else
            {
                keyMessage.gameObject.SetActive(true);
                keyNeeded.start();
            }
        }
    }
}