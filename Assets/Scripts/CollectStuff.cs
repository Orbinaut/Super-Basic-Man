﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStuff : MonoBehaviour
{
    #region Variables

    public int healthPoints = 1;
    public int maxHealth = 3;
    public int coins = 0;
    public int tenCoins = 0;
    public int ammo = 20;
    public int maxAmmo = 99;

    public int hasKey = 0;
    public int weaponLevel = 0;

    public GameObject keyIcon;
    public GameObject[] healthPointSlots;

    public GameObject deathScreen;

    public bool dead = false;

    [FMODUnity.EventRef]
    public string ammoSoundEvent;

    [FMODUnity.EventRef]
    public string coinSoundEvent;

    [FMODUnity.EventRef]
    public string hurtSoundEvent;

    [FMODUnity.EventRef]
    public string keySoundEvent;

    [FMODUnity.EventRef]
    public string deathSoundEvent;

    private FMOD.Studio.EventInstance ammoSound;
    private FMOD.Studio.EventInstance coinSound;
    private FMOD.Studio.EventInstance hurtSound;
    private FMOD.Studio.EventInstance keySound;
    private FMOD.Studio.EventInstance deathSound;

    #endregion

    void Start()
    {
        ammoSound = FMODUnity.RuntimeManager.CreateInstance(ammoSoundEvent);
        coinSound = FMODUnity.RuntimeManager.CreateInstance(coinSoundEvent);
        hurtSound = FMODUnity.RuntimeManager.CreateInstance(hurtSoundEvent);
        keySound = FMODUnity.RuntimeManager.CreateInstance(keySoundEvent);
        deathSound = FMODUnity.RuntimeManager.CreateInstance(deathSoundEvent);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Battery")){
            Destroy(other.gameObject);
            ammoSound.start();
            if (healthPoints < maxHealth)
            {
                healthPoints++;
            }
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.start();
            coins++;
        }

        else if (other.gameObject.CompareTag("1UP"))
        {
            Destroy(other.gameObject);
            ammoSound.start();
            maxHealth++;
            healthPoints = maxHealth;
        }

        else if (other.gameObject.CompareTag("Ammo"))
        {
            if (ammo < maxAmmo)
            {
                Destroy(other.gameObject);
                ammoSound.start();
                ammo += Random.Range(5,25);
            }
        }

        else if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keyIcon.gameObject.SetActive(true);
            keySound.start();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }
    }

    void Hurt(){
        healthPoints--;
        if (healthPoints > 0)
        {
            hurtSound.start();
        }
    }

    void Update(){
        if (healthPoints <= 0){
            dead = true;
            Die();
        }
        else
        {
            dead = false;
        }

        if (coins == 10)
        {
            coins = 0;
            tenCoins++;
        }

        if (tenCoins == 10)
        {
            tenCoins = 0;
        }

        healthPointSlots[maxHealth-4].gameObject.SetActive(true);
    }

    void Die()
    {
        if (dead)
        {
            Vector3 origin = new Vector3(0.0f, 1.0f, 0.0f);
            gameObject.transform.position = origin;
            deathSound.start();
            deathScreen.gameObject.SetActive(true);
            dead = false;
        }
        
        healthPoints = 1;
    }

    public void ShootAmmo()
    {
        ammo--;
    }
}