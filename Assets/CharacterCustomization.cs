using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCustomization : MonoBehaviour
{
    PlayerControls controls;
    PlayerInputManager PlayerInputManager;
    //[HideInInspector]public int playerID;
    //public CharacterCardGenerator cardGenerator;
    public List<GameObject> heads;
    public GameObject head;
    //public CharacterSelect characterSelect;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        var action = new InputAction();
        int retVal = 0;
        Vector2 retVec2 = new Vector2();

        //controls = new PlayerControls();


        controls.MainMenu.LSelection.started += ctx => retVal = -1;
        controls.MainMenu.RSelection.started += ctx => retVal = 1;
        controls.MainMenu.LSelection.started += ctx => ColorSelection(retVal);
        controls.MainMenu.RSelection.started += ctx => ColorSelection(retVal);

        controls.MainMenu.Movement.performed += ctx => retVec2 = ctx.ReadValue<Vector2>().normalized;
        controls.MainMenu.Movement.performed += ctx => CharacterSelection(retVec2);
        //controls.MainMenu.Movement.canceled += ctx => CharacterSelect(Vector2.zero);

        //head = gameObject.GetComponentInChildren<Head>();
        //Debug.Log(ctx.valueType);
        //controls.MainMenu.Alt_Selection.performed += ctx => retVal = 
        //controls.MainMenu.Alt_Selection.started += ctx => ColorSelection(retVal);
        controls.MainMenu.Cancel.started += ctx => PlayerLeft();
        CharacterSelect.instance.onPlayerSpawned(gameObject.GetComponent<PlayerInput>());
        //cardGenerator.
    }


    void ColorSelection(int value)
    {
        Debug.Log(value);
    }

    void CharacterSelection(Vector2 value)
    {
        Debug.Log(value);
        if (value.x == 1) 
        { 
            //cardGenerator.NextHead(head); 
            //head = gameObject.GetComponentInChildren<Head>(); 
        }
        if (value.x == -1) 
        { 
            //cardGenerator.PreviousHead(head); 
            //head = gameObject.GetComponentInChildren<Head>(); 
        }
    }

    public void OnPlayerJoined()
    {
        
        Debug.Log("Player Joined");
    }

    public void PlayerLeft()
    {
        // if (CharacterSelect.instance.playerInputs[i] == gameObject.GetComponent<PlayerInput>())
        // {
        //     CharacterSelect.instance.playerInputs[i] = null;
        //     Destroy(this.gameObject);
        //
        // }

        //CharacterSelect.instance.playerInputs[GetComponent<PlayerInput>().playerIndex] = null;
        Destroy(gameObject);
        Debug.Log("Player Left");
    }


    private void OnEnable()
    {
        controls.MainMenu.Enable();
    }
    private void OnDisable()
    {
        controls.MainMenu.Disable();
    }
}
