using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static PauseMenuManager instance;

    public static bool isPaused;
    public GameObject pauseMenuUI;

    public void Start(){
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Debug.Log("Instance already exists. Destroying object");
            Destroy(this);
        }
    }

    public void OpenPauseMenu(){
        Debug.Log("Opening pause menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void ClosePauseMenu(){
        Debug.Log("Closing pause menu");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void TogglePauseMenu(){
        if(isPaused){
            ClosePauseMenu();
        }else{
            OpenPauseMenu();
        }
    }

    public void SetPauseMenu(bool _pause){
        if(_pause){
            OpenPauseMenu();
        }else{
            ClosePauseMenu();
        }
    }

    public void OpenMainMenu(){
        SceneManager.LoadScene(0);
    }
}
