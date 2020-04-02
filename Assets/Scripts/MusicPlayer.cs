using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public int isRetro = 0;
    public float isNight = 0f;
    public float darkArea = 0f;

    [FMODUnity.EventRef]
    public string musicEvent;

    private FMOD.Studio.EventInstance music;

    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        music.start();
    }

    void Update()
    {
        music.setParameterByName("Retro New", isRetro);
        music.setParameterByName("Night", isNight);
        music.setParameterByName("Cave", darkArea);
    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}