using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject battery;
    private GameController gameController;
    public float speed;
    private Transform target;
    private bool flipped = false;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }

        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag("Bullet")){
                Instantiate(battery, transform.position, Quaternion.identity);
                gameController.AddScore(1);
                gameController.destroySound.Play();
                Destroy(gameObject);
            }
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (target.position.x < transform.position.x && !flipped){
            transform.Rotate(0f, 180f, 0f);
            flipped = true;
        }
        else if (target.position.x > transform.position.x && flipped){
            transform.Rotate(0f, 180f, 0f);
            flipped = false;
        }

    }
}