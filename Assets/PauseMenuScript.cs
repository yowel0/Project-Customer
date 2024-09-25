using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    
    [SerializeField]
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!pauseMenu.activeInHierarchy){
                Pause();
            }
            else{
                Continue();
            }
        }
    }

    public void Pause(){
        playerMovement.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Continue(){
        playerMovement.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void Quit(){
        Application.Quit();
    }
}
