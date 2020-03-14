using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPlayerJoined()
    {
        Debug.Log("This wokred");
    }

    public void OnPlayerLeft()
    {
        Debug.Log("Player Left");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
