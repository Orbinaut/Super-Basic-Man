using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public Animator transitionLeft;
    public Animator transitionRight;

    public string level;

    public float transitionTime = 1.0f;

    [FMODUnity.EventRef]
    public string mouseClickEvent;

    private FMOD.Studio.EventInstance mouseClickSound;

    private void Start()
    {
        Cursor.visible = true;
        rend.sprite = sprites[1];
        mouseClickSound = FMODUnity.RuntimeManager.CreateInstance(mouseClickEvent);
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
        if (gameObject.CompareTag("Start"))
        {
            Time.timeScale = 1f;
            mouseClickSound.start();
            Cursor.visible = false;
            StartCoroutine(LoadLevel());
        }

        if (gameObject.CompareTag("Quit"))
        {
            Application.Quit();
            Debug.Log("Spiel beendet.");
        }
    }

    IEnumerator LoadLevel()
    {
        transitionLeft.SetTrigger("Start");
        transitionRight.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(level);
    }
}