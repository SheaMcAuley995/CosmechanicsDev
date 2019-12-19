using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{

    public PlayerControls controls;

    void Start()
    {
        controls = new PlayerControls();

        //controls.Gameplay.Move.performed += ctx => OnMove();
        //controls.Gameplay.Move.canceled += ctx => 
    }

    void OnMove(InputValue value)
    {
        Debug.Log("Moving");
    }

    void OnMoveUp()
    {

    }

    

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
