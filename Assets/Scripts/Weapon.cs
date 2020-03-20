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
    private CharacterController2D controllerScript;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            collectScript = playerObject.GetComponent<CollectStuff>();
            controllerScript = playerObject.GetComponent<CharacterController2D>();
        }
        if (collectScript == null)
        {
            Debug.Log("Cannot find 'CollectStuff' script");
        }
        if (controllerScript == null)
        {
            Debug.Log("Cannot find 'CharacterController2D' script");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && collectScript.ammo > 0 && collectScript.hasGun)
        {
            Shoot();
            collectScript.ShootAmmo();
        }

        if (Input.GetButtonDown("Arrow") && collectScript.ammo > 0 && collectScript.hasArrow)
        {
            Arrow();
            collectScript.ShootAmmo();
        }

        if (Input.GetButtonDown("ShootBall") && collectScript.ammo > 0 && controllerScript.m_Grounded && collectScript.hasBouncer)
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