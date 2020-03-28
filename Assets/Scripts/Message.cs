using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string messageSoundEvent;

    public GameObject followingMessage;

    private FMOD.Studio.EventInstance messageSound;

    private void Start()
    {
        messageSound = FMODUnity.RuntimeManager.CreateInstance(messageSoundEvent);
        messageSound.start();
    }

    void Update()
    {
        if (Input.GetButtonDown("Arrow") || Input.GetButtonDown("Bouncer") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Shoot"))
        {
            if (gameObject.CompareTag("Tutorial"))
            {
                followingMessage.gameObject.SetActive(true);
                Destroy(gameObject);
            }
            gameObject.SetActive(false);
        }
    }
}