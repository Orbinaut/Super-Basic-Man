﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    //public float speed;
    //public float stoppingDistance;
    //public float retreatDistance;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    //public Transform player;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        //if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}

        //else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;
        //}

        //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }

        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}