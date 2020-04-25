using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorpButton : MonoBehaviour, IInteractable
{

    public FlorpFiller florpFiller;
    

    public void InteractWith()
    {
        Debug.Log("Interacted I guess");
        florpFiller.fillFlorp();
    }

}
