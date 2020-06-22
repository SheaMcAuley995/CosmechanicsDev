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
    [SerializeField] string mainMenuScene;
    [HideInInspector] public bool transitioning;


    private void Awake()
    {
        instance = this;
        playerInputs = new PlayerInput[GetComponent<PlayerInputManager>().maxPlayerCount];
        transitioning = false;
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

                playerInputs[i].gameObject.AddComponent<CharacterCustomization>();
                playerInputs[i].SwitchCurrentActionMap("CharSelect");
                break;
            }
        }

        player.GetComponent<Rigidbody>().isKinematic = true;
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

        CheckIfAllReady();
    }

    public void CheckIfAllReady()
    {
        if (numPlayersReady == numActivePlayers && numActivePlayers > 0)
        {
            PlayerPrefs.SetInt("Total Players", numActivePlayers);
            PlayerSpawn.numPlayers = numActivePlayers;

            transitioning = true;
            SceneFader.instance.FadeTo(levelSelectScene);
        }
    }
}
