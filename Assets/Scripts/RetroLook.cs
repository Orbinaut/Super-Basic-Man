using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroLook : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public GameObject retroLook;

    public bool retro = false;

    private MusicPlayer musicScript;

    [FMODUnity.EventRef]
    public string mouseClickEvent;

    private FMOD.Studio.EventInstance mouseClickSound;

    private void Start()
    {
        GameObject music = GameObject.FindWithTag("Music");
        if (music != null)
        {
            musicScript = music.GetComponent<MusicPlayer>();
        }
        if (musicScript == null)
        {
            Debug.Log("Can't find the 'MusicPlayer' script");
        }

        Cursor.visible = true;
        rend.sprite = sprites[1];
        mouseClickSound = FMODUnity.RuntimeManager.CreateInstance(mouseClickEvent);
    }

    void Update()
    {
        if (retro)
        {
            retroLook.gameObject.SetActive(true);
            musicScript.isRetro = 1;
        }
        if (!retro)
        {
            retroLook.gameObject.SetActive(false);
            musicScript.isRetro = 0;
        }
    }

    private void OnMouseOver()
    {
        rend.sprite = sprites[0];
    }

    private void OnMouseExit()
    {
        rend.sprite = sprites[1];
    }

    private void OnMouseDown()
    {
        mouseClickSound.start();
        if (gameObject.CompareTag("RetroLook"))
        {
            retro = !retro;
        }
    }
}