using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public bool day = true;
    public float dayLength = 100.0f;

    [FMODUnity.EventRef]
    public string daySoundEvent;

    [FMODUnity.EventRef]
    public string nightSoundEvent;

    private FMOD.Studio.EventInstance daySound;
    private FMOD.Studio.EventInstance nightSound;

    private MusicPlayer musicScript;

    void Start()
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

        daySound = FMODUnity.RuntimeManager.CreateInstance(daySoundEvent);
        nightSound = FMODUnity.RuntimeManager.CreateInstance(nightSoundEvent);
        Invoke("Nighttime", dayLength);
        daySound.start();
    }

    void Daytime()
    {
        day = true;
        nightSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        daySound.start();
        musicScript.isNight = 0f;
        Invoke("Nighttime", (dayLength + dayLength/2));
    }

    void Nighttime()
    {
        day = false;
        daySound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        nightSound.start();
        musicScript.isNight = 1f;
        Invoke("Daytime", dayLength/2);
    }

    private void OnDestroy()
    {
        daySound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        nightSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}