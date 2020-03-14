﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    //private Transform player;
    //private Vector2 target;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector2(player.position.x, transform.position.y);
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    DestroyProjectile();
        //}
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        DestroyProjectile();
    //    }
    //}

    //void DestroyProjectile()
    //{
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
