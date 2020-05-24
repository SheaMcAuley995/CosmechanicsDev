using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool paused;
    PlayerControls playerController;
    GameObject pauseCanvas;
    GameObject inGameCanvas;
    GameObject optionsMenu;


    private void Awake()
    {
        playerController = new PlayerControls();

        pauseCanvas  = GameObject.Find("PauseMenuCanvas");
        inGameCanvas = GameObject.Find("InGameCanvas");
        optionsMenu  = GameObject.Find("OptionsCanvas");

        pauseCanvas = pauseCanvas.transform.GetChild(0).gameObject;
        optionsMenu = optionsMenu.transform.GetChild(0).gameObject;

        paused = false;
    }


    private void OnEnable()
    {
        playerController.Gameplay.Pause.performed += Pause_Performed;
        playerController.Gameplay.Pause.Enable();
    }

    private void OnDisable()
    {
        playerController.Gameplay.Pause.performed -= Pause_Performed;
        playerController.Gameplay.Pause.Disable();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        inGameCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);
        paused = true;
    }

    private void Pause_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Start");

        if (paused)
        {
            Time.timeScale = 0f;
            inGameCanvas.gameObject.SetActive(paused);
            optionsMenu.gameObject.SetActive(false);
            paused = false;

            pauseCanvas.gameObject.SetActive(paused);
        }
        else
        {
            Time.timeScale = 1f;
            inGameCanvas.gameObject.SetActive(paused);

            paused = true;

            pauseCanvas.gameObject.SetActive(paused);
        }        

    }

}
