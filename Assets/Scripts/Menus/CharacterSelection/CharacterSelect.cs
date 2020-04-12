using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;
    
    public PlayerInput[] playerInputs;
    [Space]
    public Transform[] spawnPositions;
    [Space]
    public Material[] colorOptions;
    [Space]
    public GameObject[] headOptions;
    [Space]
    public string nextColorString = "next color";
    public string previousColorString = "previous color";
    public string nextHeadString = "next head";
    public string previousHeadString = "previous head";
    [Space]

    [HideInInspector] public int numPlayersReady = 0;
    int numActivePlayers = 0;
    [SerializeField] string levelSelectScene;


    private void Awake()
    {
        instance = this;
        playerInputs = new PlayerInput[GetComponent<PlayerInputManager>().maxPlayerCount];

        //// File IO shennannigans
        //FileStream headFile, colorFile;

        //// Customization folder
        //string folderPath = Application.persistentDataPath;
        //string optionsFolder = folderPath + "\\CharacterOptions";
        //if (!Directory.Exists(optionsFolder))
        //{
        //    Directory.CreateDirectory(optionsFolder);
        //}

        //// Available heads file
        //string headFileLocation = optionsFolder + "\\HeadOptions.dat";
        //if (File.Exists(headFileLocation))
        //{
        //    headFile = File.OpenWrite(headFileLocation);
        //}
        //else
        //{
        //    headFile = File.Create(headFileLocation);
        //}

        //// Available colours file
        //string colorFileLocation = optionsFolder + "\\ColorOptions.dat";
        //if (File.Exists(colorFileLocation))
        //{
        //    colorFile = File.OpenWrite(colorFileLocation);
        //}
        //else
        //{
        //    colorFile = File.Create(colorFileLocation);
        //}

        //// Binary formatting data to the file
        //BinaryFormatter bf = new BinaryFormatter();
        //bf.Serialize(colorFile, materialColors);
        //bf.Serialize(headFile, headArray);
    }

    public void onPlayerSpawned(PlayerInput player)
    {
        numActivePlayers++;

        for (int i = 0; i < playerInputs.Length; i++)
        {
            if (playerInputs[i] == null)
            {
                playerInputs[i] = player;
                player.transform.position = spawnPositions[i].position;
                player.transform.rotation = spawnPositions[i].rotation;
                break;
            }
        }
    }

    public void onResetPlayer(PlayerInput player)
    {
        player.transform.position = spawnPositions[player.playerIndex].position;
        player.transform.rotation = spawnPositions[player.playerIndex].rotation;
    }

    public void onPlayerLeft(PlayerInput player)
    {
        numActivePlayers = 0;
        for (int i = 0; i < playerInputs.Length; i++)
        {
            if (playerInputs[i] != null)
            {
                numActivePlayers++;
            }
        }
        playerInputs[player.playerIndex] = null;
    }

    public void CheckIfAllReady()
    {
        if (numPlayersReady == numActivePlayers)
        {
            PlayerPrefs.SetInt("Total Players", numActivePlayers);
            SceneFader.instance.FadeTo(levelSelectScene);
        }
    }
}
