using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollectStuff : MonoBehaviour
{
    public AudioSource ammoSound;
    public AudioSource coinSound;
    public AudioSource keySound;
    public AudioSource hurtSound;
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

    void Start(){
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Battery")){
            Destroy(other.gameObject);
            ammoSound.Play();
            if (healthPoints < maxHealth)
            {
                healthPoints++;
            }
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinSound.Play();
            coins++;
        }

        else if (other.gameObject.CompareTag("1UP"))
        {
            Destroy(other.gameObject);
            ammoSound.Play();
            maxHealth++;
            healthPoints = maxHealth;
        }

        else if (other.gameObject.CompareTag("Ammo"))
        {
            if (ammo < maxAmmo)
            {
                Destroy(other.gameObject);
                ammoSound.Play();
                ammo += Random.Range(5,25);
            }
        }

        else if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keyIcon.gameObject.SetActive(true);
            keySound.Play();
            hasKey++;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }
    }

    void Hurt(){
        healthPoints--;
        hurtSound.Play();
    }

    void Update(){
        if (healthPoints <= 0){
            Die();
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
        Destroy(gameObject);
        Reload();
    }

    public void ShootAmmo()
    {
        ammo--;
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}