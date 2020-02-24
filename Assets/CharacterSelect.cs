using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;
    
    [HideInInspector]public PlayerInput[] playerInputs;
    
    public Transform[] spawnPositions;

    private void Awake()
    {
        instance = this;
        playerInputs = new PlayerInput[4];
    }

    private void Start()
    {
        //inputManager = GetComponent<PlayerInputManager>();
        //inputManager.onPlayerJoined += onSpawnedPlayer(new PlayerInput player);
    }

    public void onPlayerSpawned(PlayerInput player)
    {
        for(int i = 0; i < 4; i++ )
        {
            if(playerInputs[i] == null)
            {
                playerInputs[i] = player;
                player.transform.position = spawnPositions[i].position;
                player.transform.rotation = spawnPositions[i].rotation;
                break;
            }
        }

    }
}
