using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;
    
    public PlayerInput[] playerInputs;


    public CharacterCardGenerator[] characterCards;
    
    public Transform[] spawnPositions;
    public Material[] materials;
    public List<Material> materialsList;
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
                //playerInputs[i] = player;
                player.transform.position = spawnPositions[i].position;
                player.transform.rotation = spawnPositions[i].rotation;
                //player.playerIndex
                //player.GetComponent<CharacterCustomization>().cardGenerator = characterCards[i];
                //characterCards[i].newPlayer = player.gameObject;
                break;
            }
        }
        //player.GetComponent<CharacterCustomization>().characterSelection = this;


    }
}
