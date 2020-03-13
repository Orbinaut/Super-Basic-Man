using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject arrowPrefab;
    public GameObject bouncyBallPrefab;
    public AudioSource shotSound;
    public AudioSource arrowSound;

    private CollectStuff collectScript;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            collectScript = playerObject.GetComponent<CollectStuff>();
        }
        if (collectScript == null)
        {
            Debug.Log("Cannot find 'CollectStuff' script");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && collectScript.ammo > 0)
        {
            Shoot();
            collectScript.ShootAmmo();
        }

        if (Input.GetButtonDown("Arrow") && collectScript.ammo > 0)
        {
            Arrow();
            collectScript.ShootAmmo();
        }

        if (Input.GetButtonDown("ShootBall") && collectScript.ammo > 0)
        {
            BouncyBall();
            collectScript.ShootAmmo();
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shotSound.Play();
    }

    void Arrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        arrowSound.Play();
    }

    void BouncyBall()
    {
        Instantiate(bouncyBallPrefab, firePoint.position, firePoint.rotation);
        shotSound.Play();
    }
}