using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{



    public Vector3[] SpawnPositoins;
    public GameObject PlayerObject;
    PlayerInputManager inputManager;
    
    void Start()
    {
        var allGamepads = Gamepad.all;
        for (int i = 0; i < SpawnPositoins.Length; i++)
        {
            GameObject newPlayer = Instantiate(PlayerObject, SpawnPositoins[i], Quaternion.identity);
            Cube newPlayerController = newPlayer.AddComponent<Cube>();
           
            newPlayerController.controls = new PlayerControls();
            //newPlayerController.controls.devices
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        for(int i = 0; i < SpawnPositoins.Length; i++ )
        {
            Gizmos.DrawSphere(SpawnPositoins[i], 1);
        }
        
    }
}
