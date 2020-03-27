using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElement : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    private void Start()
    {
        Cursor.visible = true;
        rend.sprite = sprites[1];
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
    }
}