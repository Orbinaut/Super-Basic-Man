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
    public TextMeshProUGUI CoinCount;
    public TextMeshProUGUI AmmoCount;
    public TextMeshProUGUI keyCount;
    public TextMeshProUGUI healthCount;
    public int healthPoints = 1;
    public int maxHealth = 3;
    public int coins = 0;
    public int ammo = 20;

    public int hasKey = 0;

    public GameObject thinkingBubble;

    public string nextLevel;

    void Start(){
        SetCountText();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Battery")){
            Destroy(other.gameObject);
            collectSound.Play();
            if (healthPoints < maxHealth){
                healthPoints++;
                SetCountText();
            }
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            coins++;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("1UP"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            maxHealth = 4;
            healthPoints = 4;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Ammo"))
        {
            Destroy(other.gameObject);
            collectSound.Play();
            ammo += 10;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Key"))
        {
            hasKey++;
            thinkingBubble.gameObject.SetActive(false);
            Destroy(other.gameObject);
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Lethal"))
        {
            Die();
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Door"))
        {
            if (hasKey == 4)
            {
                Debug.Log("Level beendet.");
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                Debug.Log("Schlüssel wird benötigt.");
                thinkingBubble.gameObject.SetActive(true);
            }
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
            SetCountText();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Reload();
    }

    public void ShootAmmo()
    {
        ammo--;
        SetCountText();
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    void SetCountText(){
        CoinCount.text = "Coins: " + coins;
        AmmoCount.text = "Ammo: " + ammo;
        keyCount.text = "Keys: " + hasKey;
        healthCount.text = "Health: " + healthPoints;
    }
}