using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTen : MonoBehaviour
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
        rend.sprite = sprites[collectScript.tenCoins];
    }
}