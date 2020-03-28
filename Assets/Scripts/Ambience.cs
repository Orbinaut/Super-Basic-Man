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

    void Start()
    {
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
        Invoke("Nighttime", (dayLength + dayLength/2));
    }

    void Nighttime()
    {
        day = false;
        daySound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        nightSound.start();
        Invoke("Daytime", dayLength/2);
    }
}