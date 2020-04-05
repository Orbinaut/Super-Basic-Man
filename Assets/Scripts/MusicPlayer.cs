using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public int isRetro = 0;
    public float isNight = 0f;
    public float darkArea = 0f;

    public GameObject endMessage;
    public GameObject player;
    public GameObject endingBlink;
    public GameObject pauseObject;

    public Animator transitionLeft;
    public Animator transitionRight;
    public Animator gemstone;

    public float transitionTime = 1.0f;

    private CollectStuff collectScript;

    public Collider2D playerColliderFeet;
    public Collider2D playerColliderHead;

    public bool ambienceOff = false;

    [FMODUnity.EventRef]
    public string musicEvent;

    [FMODUnity.EventRef]
    public string endingMusicEvent;

    [FMODUnity.EventRef]
    public string gemstoneSoundEvent;

    private FMOD.Studio.EventInstance music;
    private FMOD.Studio.EventInstance endingMusic;
    private FMOD.Studio.EventInstance gemstoneSound;

    public BoxCollider2D myCollider;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            collectScript = player.GetComponent<CollectStuff>();
        }
        if (collectScript == null)
        {
            Debug.Log("Can't find the 'CollectStuff' script");
        }

        music = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        endingMusic = FMODUnity.RuntimeManager.CreateInstance(endingMusicEvent);
        gemstoneSound = FMODUnity.RuntimeManager.CreateInstance(gemstoneSoundEvent);
        music.start();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gemstoneSound.start();
            gemstone.SetBool("isDiscovered", true);
            Destroy(pauseObject.gameObject);
            music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            endingMusic.start();
            Invoke("ShowEndMessage", 8.7f);
            myCollider.enabled = false;
        }
    }

    void Update()
    {
        music.setParameterByName("Retro New", isRetro);
        music.setParameterByName("Night", isNight);
        music.setParameterByName("Cave", darkArea);
    }

    void ShowEndMessage()
    {
        endMessage.gameObject.SetActive(true);
        ambienceOff = true;
        collectScript.weaponLevel = 0;
        collectScript.coins = 0;
        Vector3 nowhere = new Vector3(250.0f, -64.0f, 0.0f);
        player.gameObject.transform.position = nowhere;
        playerColliderFeet.enabled = false;
        playerColliderHead.enabled = false;
        Invoke("LoadMenu", 29.5f);
        Invoke("ShowBlink", 20f);
        
    }

    void ShowBlink()
    {
        endingBlink.gameObject.SetActive(true);
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transitionLeft.SetTrigger("Start");
        transitionRight.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Start");
    }

    private void OnDestroy()
    {
        music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}