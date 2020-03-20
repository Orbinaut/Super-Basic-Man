using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CollectStuff : MonoBehaviour
{
    public AudioSource collectSound;
    public AudioSource hurtSound;
    public int healthPoints = 1;
    public int maxHealth = 3;
    public int coins = 0;
    public int ammo = 20;

    public bool hasKey = false;
    public bool hasBouncer = false;
    public bool hasArrow = false;
    public bool hasGun = false;

    public GameObject keyIcon;
    public GameObject[] healthPointSlots;
    //public GameObject[] healthPointsGreen;

    void Start(){
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Battery")){
            Destroy(other.gameObject);
            collectSound.Play();
            if (healthPoints < maxHealth)
            {
                healthPoints++;
            }
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            coins++;
        }

        else if (other.gameObject.CompareTag("1UP"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            maxHealth++;
            healthPoints = maxHealth;
        }

        else if (other.gameObject.CompareTag("Ammo"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            ammo += Random.Range(5,25);
        }

        else if (other.gameObject.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
            keyIcon.gameObject.SetActive(true);
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }

        else if (other.gameObject.CompareTag("Lethal"))
        {
            Die();
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
        }

        healthPointSlots[maxHealth-4].gameObject.SetActive(true);

        //healthPointsGreen[healthPoints - 1].gameObject.SetActive(true);
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