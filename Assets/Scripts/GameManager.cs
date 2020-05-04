using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public delegate void InitializeScene();
    InitializeScene initializeScene;

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

        initializeScene += debugVoid();
    }

    private InitializeScene debugVoid()
    {
        Debug.Log("Scene Inialized");

        throw new NotImplementedException();
    }

    public void Initialize()
    {
        initializeScene();
    }


}

