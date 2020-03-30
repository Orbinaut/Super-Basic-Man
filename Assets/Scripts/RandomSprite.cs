using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite[] sprites;

    //public GameObject impact;

    private int spriteNumber;

    private void Start()
    {
        spriteNumber = Random.Range(0, sprites.Length);
    }

    void Update()
    {
        rend.sprite = sprites[spriteNumber];
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Instantiate(impact, transform.position, transform.rotation);
    //}
}