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

    public TextMeshProUGUI enemyCountText;

    public AudioSource deathSound;
    public AudioSource destroySound;
    public AudioSource[] Music;

    #endregion

    void Start(){
        StartCoroutine(SpawnEnemies());
        int musicIndex = Random.Range(0,Music.Length);
        //Music[musicIndex].Play();
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

    public void GameOver(){
        deathSound.Play();
        Invoke("TryAgain", 2);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Game Over");
    }
}
