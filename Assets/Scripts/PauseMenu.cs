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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton9)){
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
        SceneManager.LoadScene("Menu");
        Resume();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
