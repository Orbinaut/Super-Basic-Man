using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public bool playerIsInCave = false;

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
            musicScript.inCave = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            musicScript.inCave = 0;
        }
    }
}