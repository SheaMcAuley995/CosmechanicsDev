using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTracker : MonoBehaviour
{
    public int playerCount;

    private void Awake()
    {
        PlayerTracker[] objs = GameObject.FindObjectsOfType<PlayerTracker>();
        
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch(level)
        {
            case 1:
                {
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Char");
                    playerCount = players.Length;
                    break;
                }

        }
    }

}
