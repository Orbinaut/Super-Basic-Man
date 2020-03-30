using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    private CollectStuff collectScript;

    public SpriteRenderer rend;

    public Sprite[] sprites;

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
    }

    void Update()
    {
        if (gameObject.CompareTag("Ammo Counter"))
        {
            rend.sprite = sprites[collectScript.ammo];
        }
        else
        {
            rend.sprite = sprites[collectScript.coins];
        }
    }
}