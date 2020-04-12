using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;

    public PlayerInput[] playerInputs;
    [Space]
    public Transform[] spawnPositions;
    [Space]
    public Material[] colorOptions;
    [Space]
    public GameObject[] headOptions;
    [Space]
    public Transform[] coloredPlayerObjects;


    public PlayerSpawn(int numPlayers, Transform[] spawnPoints, GameObject playerToSpawn)
    {
        playerInputs = new PlayerInput[numPlayers];

        spawnPoints = new Transform[4];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPositions[i] = spawnPoints[i];
        }

        playerPrefab = playerToSpawn;

        SpawnPlayers(numPlayers); // I know this is bad practice. 
    }

    void SpawnPlayers(int players)
    {
        for (int i = 0; i < players; i++)
        {
            // Spawn the player
            GameObject newPlayer = Instantiate(playerPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
            newPlayer.name = "Player " + i.ToString();
            playerInputs[i] = newPlayer.GetComponent<PlayerInput>();

            // Set the player's selected head
            Transform headToReplace = newPlayer.FindComponentInChildWithTag<Transform>("Head");
            GameObject newHead = Instantiate(headOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Head")], headToReplace.position, headToReplace.rotation, headToReplace.parent);
            Destroy(headToReplace.gameObject);

            // Set the player's selected colour
            for (int j = 0; j < coloredPlayerObjects.Length; j++)
            {
                // Set the suit's colour
                if (!coloredPlayerObjects[i].GetComponent<Image>())
                {
                    coloredPlayerObjects[i].GetComponent<Renderer>().material = colorOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Color")];
                }
                // Set the floor gear image's colour
                else
                {
                    Color emissColor = colorOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Color")].GetColor("_EmissionColor");
                    coloredPlayerObjects[i].GetComponent<Image>().color = emissColor;
                }
            }
        }
    }
}
