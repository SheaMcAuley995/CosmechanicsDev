using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigurations;

    [SerializeField]
    private int MaxPlayers = 4;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Singleton Trying to creat another instance of singleton!!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigurations = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigurations[index].PlayerMaterial = color;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigurations[index].IsReady = true;

        if(playerConfigurations.Count == MaxPlayers && playerConfigurations.All(p => p.IsReady))
        {
            GameManager.Instance.LoadScene("LevelSelectUpdated");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player Joined" + pi.playerIndex);

        pi.transform.SetParent(transform);
        if(playerConfigurations.Any(p => p.playerIndex == pi.playerIndex))
        {
            playerConfigurations.Add(new PlayerConfiguration(pi));
        }
    }
}

public class PlayerConfiguration
{

    public PlayerConfiguration(PlayerInput pi)
    {
        playerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; set; }
    public int playerIndex { get; set; }
    public bool IsReady { get; set; }
    public Material PlayerMaterial { get; set; }

}

