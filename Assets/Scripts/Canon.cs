using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject bullet;
    public Transform firePoint;

    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }

        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
