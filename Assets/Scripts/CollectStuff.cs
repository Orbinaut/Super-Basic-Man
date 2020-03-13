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
    public TextMeshProUGUI LifeCount;
    public TextMeshProUGUI CoinCount;
    public GameController gameController;
    public int healthPoints = 1;
    public int maxHealth = 3;
    public int Lifes = 3;
    public int coins = 0;

    private int count;
    public int hasKey = 0;

    public GameObject thinkingBubble;

    public string nextLevel;

    void Start(){
        count = 0;
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

        else if (other.gameObject.CompareTag("Key"))
        {
            hasKey++;
            thinkingBubble.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Hurt();
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

        if (coins == 5)
        {
            Lifes++;
            coins = 0;
            SetCountText();
        }
    }

    void Die(){
        Lifes--;
        Destroy(gameObject);

        if (Lifes <= 0)
        {
            gameController.GameOver();
        }
        else
        {
            Reload();
        }
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    void SetCountText(){
        LifeCount.text = "Lifes: " + Lifes;
        CoinCount.text = "Coins: " + coins;
    }
}
