using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroLook : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    public GameObject retroLook;

    public bool retro = false;

    private void Start()
    {
        Cursor.visible = true;
        rend.sprite = sprites[1];
    }

    void Update()
    {
        if (retro)
        {
            retroLook.gameObject.SetActive(true);
        }
        if (!retro)
        {
            retroLook.gameObject.SetActive(false);
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
        if (gameObject.CompareTag("RetroLook"))
        {
            retro = !retro;
        }
    }
}