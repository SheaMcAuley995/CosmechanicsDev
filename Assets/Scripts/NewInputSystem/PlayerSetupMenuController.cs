using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int PlayerIndex;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled = false;

    public void setPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    private void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void setColor(Material color)
    { 
         if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerColor(PlayerIndex, color);

    }

    public void ReadyPlayer()
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
    }
}
