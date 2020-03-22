using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
  public static bool gameIsPaused = false;

  public GameObject pauseMenuUI;

  public AudioMixer audioMixer;

    void Update()
    {
        if (Input.GetButtonDown("Pause")){
            if (gameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        audioMixer.SetFloat("volume", 0f);
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = true;
        audioMixer.SetFloat("volume", -12f);
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Start");
        Resume();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
