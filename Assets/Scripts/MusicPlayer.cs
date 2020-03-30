using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float isRetro = 0f;
    public float isNight = 0f;

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
        music.setParameterByName("Retro", isRetro);
        music.setParameterByName("Night", isNight);
    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}