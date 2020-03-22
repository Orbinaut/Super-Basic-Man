using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public Animator myAnimator;

    public AudioSource openingSound;

    public bool open = false;

    private bool soundplayed = false;

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
            openingSound.Play();
            soundplayed = true;
        }
    }
}