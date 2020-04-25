using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorpFiller : MonoBehaviour
{
    public Florp florp;

    public FlorpButton curButton;
    public FlorpButton buttonA;
    public FlorpButton buttonB;

    public Transform holdPostion;


    private void Start()
    {
        curButton = buttonA;
    }
    public void fillFlorp()
    {
        if (florp != null)
        {
            if (curButton == buttonA)
            {
                florp.fillFlorp();
                curButton = buttonB;
            }
            else if (curButton == buttonB)
            {
                florp.fillFlorp();
                curButton = buttonA;
            }
        }
    }
}
