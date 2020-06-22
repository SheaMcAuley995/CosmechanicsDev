using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public UnityEvent sceneInitialize;
    //public UnityEvent sceneGameTick;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this.gameObject);
        //sceneInitialize += debugVoid();
    }




    public void LoadScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
