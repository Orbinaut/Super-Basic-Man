﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables

    public Transform firePoint;
    public GameObject bullet;
    public GameObject arrow;
    public GameObject bouncer;

    public float distance = 1f;
    public Transform bouncerCheck;
    public Transform bouncerSideCheck;

    [FMODUnity.EventRef]
    public string arrowSoundEvent;

    [FMODUnity.EventRef]
    public string shotSoundEvent;

    private CollectStuff collectScript;
    private CharacterController2D controllerScript;

    private FMOD.Studio.EventInstance arrowSound;
    private FMOD.Studio.EventInstance shotSound;

    #endregion

    void Start()
    {
        arrowSound = FMODUnity.RuntimeManager.CreateInstance(arrowSoundEvent);
        shotSound = FMODUnity.RuntimeManager.CreateInstance(shotSoundEvent);

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            collectScript = player.GetComponent<CollectStuff>();
            controllerScript = player.GetComponent<CharacterController2D>();
        }
        if (collectScript == null)
        {
            Debug.Log("Can't find the 'CollectStuff' script");
        }
        if (controllerScript == null)
        {
            Debug.Log("Can't find the 'CharacterController2D' script");
        }
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(bouncerCheck.position, Vector2.down, distance);
        RaycastHit2D sideInfo = Physics2D.Raycast(bouncerCheck.position, Vector2.right, distance);

        if (groundInfo.collider == false && sideInfo.collider == false)
        {
            Debug.Log("Can't put a bouncer here.");
        }

        if (Input.GetButtonDown("Shoot") && collectScript.ammo > 0 && collectScript.weaponLevel >= 1)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Bouncer") && collectScript.ammo > 0 && controllerScript.m_Grounded && collectScript.weaponLevel >= 2 && groundInfo.collider && !sideInfo.collider)
        {
            Bouncer();
        }

        if (Input.GetButtonDown("Arrow") && collectScript.ammo > 0 && collectScript.weaponLevel >= 3)
        {
            Arrow();
        }
    }

    void Shoot(){
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        shotSound.start();
        collectScript.ShootAmmo();
    }

    void Arrow()
    {
        Instantiate(arrow, firePoint.position, firePoint.rotation);
        arrowSound.start();
        collectScript.ShootAmmo();
    }

    void Bouncer()
    {
        Instantiate(bouncer, firePoint.position, firePoint.rotation);
        shotSound.start();
        collectScript.ShootAmmo();
    }
}