using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Variables

    public GameObject enemy;

    public int spawnX = 60;
    public int spawnY = 9;
    public int enemyCount = 10;
    public int spawnWait = 3;
    public int killCount = 0;

    public TextMeshProUGUI enemyCountText;
    public TextMeshProUGUI highscore;

    public AudioSource deathSound;
    public AudioSource destroySound;
    public AudioSource[] Music;

    #endregion

    void Start(){
        StartCoroutine(SpawnEnemies());
        killCount = 0;
        highscore.text = "";
        int musicIndex = Random.Range(0,Music.Length);
        //Music[musicIndex].Play();
        UpdateScore();
    }

    IEnumerator SpawnEnemies()
    {
        for (int j = spawnWait; j > 0; j--){
            for(int i = 0; i < enemyCount; i++){
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnX, spawnX), spawnY, 0f);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(j);
            }
        }
    }

    public void AddScore (int kill)
    {
        killCount += kill;
        UpdateScore ();
    }

    void UpdateScore(){
        enemyCountText.text = "Kills: " + killCount;
    }

    public void GameOver(){
        //Time.timeScale = 0f;
        highscore.text = "Highscore: " + killCount;
        deathSound.Play();
        Invoke("TryAgain", 2);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game Over");
    }

    void Update(){
        if (Input.GetButtonDown("Restart")){
            SceneManager.LoadScene("Level");
            Time.timeScale = 1f;
        }
    }
}
