using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    public void OnMove(CallbackContext context)
    { 
        player.movementVector = context.ReadValue<Vector2>();
    }

    public void OnPickupObject(CallbackContext context)
    {
        player.interact();
    }
}
