using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public float speed = 1.0f;
    public float dayLength = 100.0f;

    [FMODUnity.EventRef]
    public string daytimeSoundEvent;

    private FMOD.Studio.EventInstance daytimeSound;

    private MusicPlayer musicScript;

    public GameObject shootingStar;

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
        daytimeSound = FMODUnity.RuntimeManager.CreateInstance(daytimeSoundEvent);
        daytimeSound.start();
        Invoke("Nighttime", 85f);
    }

    void Daytime()
    {
        musicScript.isNight = 0f;
        Invoke("Nighttime", dayLength + dayLength/2);
    }

    void Nighttime()
    {
        musicScript.isNight = 1f;
        Invoke("Daytime", dayLength/2);
        shootingStar.gameObject.SetActive(true);
    }

    void Update()
    {
        daytimeSound.setParameterByName("Night", Mathf.Lerp(0, 1, Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1.0f)));
        if (musicScript.ambienceOff)
        {
            daytimeSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OnDestroy()
    {
        daytimeSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}