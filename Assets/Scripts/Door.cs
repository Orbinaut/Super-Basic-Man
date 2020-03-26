using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public Animator myAnimator;

    public bool open = false;

    [FMODUnity.EventRef]
    public string openingSoundEvent;

    private bool soundplayed = false;

    private FMOD.Studio.EventInstance openingSound;

    private void Start()
    {
        openingSound = FMODUnity.RuntimeManager.CreateInstance(openingSoundEvent);
    }

    void Update()
    {
        if (open)
        {
            rend.sprite = sprites[1];
            DoorOpens();
        }
    }

    void DoorOpens()
    {
        myAnimator.SetBool("isOpen", true);
        if (!soundplayed)
        {
            openingSound.start();
            soundplayed = true;
        }
    }
}