using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public GameObject credits;

    public bool retro = false;

    private void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        if (retro)
        {
            rend.sprite = sprites[2];
            credits.gameObject.SetActive(true);
        }
        if (!retro)
        {
            rend.sprite = sprites[0];
            credits.gameObject.SetActive(false);
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
        if (gameObject.CompareTag("Start"))
        {
            SceneManager.LoadScene("Level");
        }
        if (gameObject.CompareTag("Quit"))
        {
            Application.Quit();
            Debug.Log("Spiel beendet.");
        }
        if (gameObject.CompareTag("Credits"))
        {
            credits.gameObject.SetActive(true);
        }

        if (gameObject.CompareTag("RetroLook"))
        {
            retro = !retro;
        }
    }
}