using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public bool insideDarkArea = false;

    private MusicPlayer musicScript;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicScript.darkArea = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicScript.darkArea = 0f;
        }
    }
}