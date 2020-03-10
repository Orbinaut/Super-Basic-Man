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
    public TextMeshProUGUI countText;
    public GameController gameController;
    public int healthPoints = 3;
    public int maxHealth = 3;

    private int count;

    void Start(){
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PickUp")){
            Destroy(other.gameObject);
            collectSound.Play();
            if (healthPoints < maxHealth){
                healthPoints++;
                SetCountText();
            }
        }
        if (other.gameObject.CompareTag("Enemy")){
            Hurt();
            SetCountText();
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
    }

    void Die(){
        Destroy(gameObject);
        gameController.GameOver(); 
    }

    void SetCountText(){
        countText.text = "Health: " + healthPoints;
    }
}
