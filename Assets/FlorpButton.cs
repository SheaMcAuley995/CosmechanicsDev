﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorpButton : MonoBehaviour, IInteractable
{

    public FlorpFiller florpFiller;
    public MeshRenderer meshRenderer;
    public bool On;

    public void InteractWith()
    {
        if(On)
        {
            Debug.Log("Interacted I guess");
            florpFiller.fillFlorp();
        }

    }

}
