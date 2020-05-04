using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    public static GameObject[] playerPrefabs = new GameObject[4];
    public static Vector3[] spawnPositions = new Vector3[4];
    public static CameraMultiTarget cameraMultiTarget;
    public static int numPlayers; // This is automatically set when the game transitions from character selection to level selection

    // This is the array of game objects that will be added as targets to the camera script once all players are spawned
    //GameObject[] spawnedPlayers = new GameObject[4];
    List<GameObject> spawnedPlayers = new List<GameObject>();

    // Constructor for spawning players
    public PlayerSpawn(Vector3[] spawnPoints, CameraMultiTarget camera)
    {
        // Set spawn points
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPositions[i] = spawnPoints[i];
        }

        if (numPlayers > 0)
        {
            // Spawn players
            for (int i = 0; i < numPlayers; i++)
            {
                GameObject newPlayer = Instantiate(playerPrefabs[i], spawnPoints[i], Quaternion.Euler(Vector3.zero));
                newPlayer.GetComponent<PlayerInput>().actions = (InputActionAsset)Resources.Load("Assets/zExperimental/PlayerControls.inputactions");
                //newPlayer.GetComponent<PlayerInput>().SwitchCurrentActionMap("Gameplay");

                spawnedPlayers.Add(newPlayer);

                newPlayer.GetComponent<Player>().cameraTrans = camera.GetComponent<Camera>().transform;
            }
        }
        else
        {
            GameObject newPlayer = Instantiate(ExampleGameController.instance.playerPrefab, spawnPoints[0], Quaternion.Euler(Vector3.zero));
            newPlayer.GetComponent<PlayerInput>().actions = (InputActionAsset)Resources.Load("Assets/zExperimental/PlayerControls.inputactions");
            //newPlayer.GetComponent<PlayerInput>().SwitchCurrentActionMap("Gameplay");

            spawnedPlayers.Add(newPlayer);

            newPlayer.GetComponent<Player>().cameraTrans = camera.GetComponent<Camera>().transform;
        }
        // Set camera targets
        camera.SetTargets(spawnedPlayers.ToArray());
    }


    #region Old Constructor method
    //public GameObject playerPrefab;

    //public PlayerInput[] playerInputs;
    //[Space]
    //public Transform[] spawnPositions;
    //[Space]
    //public Material[] colorOptions;
    //[Space]
    //public GameObject[] headOptions;
    //[Space]
    //public Transform[] coloredPlayerObjects;


    //public PlayerSpawn(int numPlayers, Transform[] spawnPoints, GameObject playerToSpawn)
    //{
    //    playerInputs = new PlayerInput[numPlayers];

    //    spawnPoints = new Transform[4];
    //    for (int i = 0; i < spawnPoints.Length; i++)
    //    {
    //        spawnPositions[i] = spawnPoints[i];
    //    }

    //    playerPrefab = playerToSpawn;

    //    SpawnPlayers(numPlayers); // I know this is bad practice. 
    //}

    //void SpawnPlayers(int players)
    //{
    //    for (int i = 0; i < players; i++)
    //    {
    //        // Spawn the player
    //        GameObject newPlayer = Instantiate(playerPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
    //        newPlayer.name = "Player " + i.ToString();
    //        playerInputs[i] = newPlayer.GetComponent<PlayerInput>();

    //        // Set the player's selected head
    //        Transform headToReplace = newPlayer.FindComponentInChildWithTag<Transform>("Head");
    //        GameObject newHead = Instantiate(headOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Head")], headToReplace.position, headToReplace.rotation, headToReplace.parent);
    //        Destroy(headToReplace.gameObject);

    //        // Set the player's selected colour
    //        for (int j = 0; j < coloredPlayerObjects.Length; j++)
    //        {
    //            // Set the suit's colour
    //            if (!coloredPlayerObjects[i].GetComponent<Image>())
    //            {
    //                coloredPlayerObjects[i].GetComponent<Renderer>().material = colorOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Color")];
    //            }
    //            // Set the floor gear image's colour
    //            else
    //            {
    //                Color emissColor = colorOptions[PlayerPrefs.GetInt("Player " + i.ToString() + " Color")].GetColor("_EmissionColor");
    //                coloredPlayerObjects[i].GetComponent<Image>().color = emissColor;
    //            }
    //        }
    //    }
    //}
    #endregion
}
