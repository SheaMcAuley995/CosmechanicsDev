using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;

public class CharacterCustomization : MonoBehaviour
{
    PlayerInput player;
    Player playerMovement;

    [SerializeField] Transform headToReplace;
    int currentHead;

    [SerializeField] Transform suitTransform;
    [SerializeField] Image[] coloredImages;
    int currentColor;

    [SerializeField] Image readyBar; // Not implemented yet. Frankly I might just wait for Unity to update the input system more to make holding buttons easier. 
    bool ready = false;

    //Materialize materializeEffect;
    //bool materializing = false;


    void Awake()
    {
        player = GetComponent<PlayerInput>();
        playerMovement = GetComponent<Player>();
        player.SwitchCurrentActionMap("CharSelect");
        playerMovement.cameraTrans = Camera.main.transform;

        /// WARNING: THIS METHOD SEEMINGLY APPLIES TO ALL CONTROLLERS PLUGGED IN!
        #region Experimental/broken Method
        /* var action = new InputAction();
        int retVal = 0;
        Vector2 retVec2 = new Vector2();


        controls.MainMenu.LSelection.started += ctx => retVal = -1;
        controls.MainMenu.RSelection.started += ctx => retVal = 1;
        controls.MainMenu.LSelection.started += ctx => ColorSelection(retVal);
        controls.MainMenu.RSelection.started += ctx => ColorSelection(retVal);

        controls.MainMenu.Movement.performed += ctx => retVec2 = ctx.ReadValue<Vector2>().normalized;
        controls.MainMenu.Movement.performed += ctx => CharacterSelection(retVec2);
        controls.MainMenu.Movement.canceled += ctx => CharacterSelect(Vector2.zero);

        Debug.Log(ctx.valueType);
        controls.MainMenu.Alt_Selection.performed += ctx => retVal =
        controls.MainMenu.Alt_Selection.started += ctx => ColorSelection(retVal);
        controls.MainMenu.Cancel.started += ctx => PlayerLeft(); */
        #endregion
    }

    void Start()
    {
        // Set random starting head
        headToReplace = gameObject.FindComponentInChildWithTag<Transform>("Head");
        currentHead = Random.Range(0, CharacterSelect.instance.headOptions.Length);
        NewHead(null);

        // Set random starting color
        currentColor = Random.Range(0, CharacterSelect.instance.colorOptions.Length);
        NewColor(null);

        playerMovement.enabled = false;
    }

    /// <summary>
    /// Input manager functions for selecting a new head.
    /// </summary>
    void OnMovementRight()
    {
        NewHead("next head");
    }
    void OnMovementLeft()
    {
        NewHead("previous head");
    }

    /// <summary>
    /// Input manager functions for selecting a new colour.
    /// </summary>
    void OnAltMovementRight()
    {
        NewColor("next color");
    }
    void OnAltMovementLeft()
    {
        NewColor("previous color");
    }

    /// <summary>
    /// Input manager functions for readying up, cancelling, and un-joining.
    /// </summary>
    void OnConfirm()
    {
        if (!ready)
        {
            // Enable player movement
            ready = true;
            player.SwitchCurrentActionMap("Gameplay");
            playerMovement.enabled = true;

            // Switch player animations out of Character Select state
            Animator bodyAnimator = GetComponent<Animator>();
            Animator headAnimator = headToReplace.GetComponent<Animator>();
            bodyAnimator.SetBool("CharSelect", false);
            bodyAnimator.Play("Idle", -1, 0);
            headAnimator.SetBool("CharSelect", false);
            headAnimator.Play("Idle", -1, 0);

            // Update number of players ready & check if all ready
            CharacterSelect.instance.numPlayersReady++;
            CharacterSelect.instance.CheckIfAllReady();

            // Store player's selected head & color into PlayerPrefs
            PlayerPrefs.SetInt("Player " + player.playerIndex.ToString() + " Head", currentHead);
            PlayerPrefs.SetInt("Player " + player.playerIndex.ToString() + " Color", currentColor);

            //string fileDestination = Application.persistentDataPath + "\\SelectedCharacterInfo.dat";
            //FileStream file;

            // Creates a temporary prefab of this player which can then be assigned as a spawnable Game Object in the spawner script
            //GameObject selectedCharPrefab = PrefabUtility.CreatePrefab("Assets/Prefabs/Zach/CharSelect" + player.gameObject.name + player.playerIndex + ".prefab", player.gameObject, ReplacePrefabOptions.ReplaceNameBased);
            //GameObject selectedCharPrefab = PrefabUtility.SaveAsPrefabAsset(player.gameObject, "Assets/Prefabs/Zach/CharSelect" + player.gameObject.name + player.playerIndex + ".prefab");
            //selectedCharPrefab.GetComponent<CharacterCustomization>().enabled = false;

            // Sets this player's created prefab to its respective position in the spawner's array of game objects to spawn
            //PlayerSpawn.playerPrefabs[player.playerIndex] = selectedCharPrefab;
        }
    }
    void OnCancel()
    {
        if (!ready) // Un-join
        {
            CharacterSelect.instance.onPlayerLeft(player);
            Destroy(this.gameObject);
        }
        else // Un-ready
        {
            CharacterSelect.instance.numPlayersReady--;

            ready = false;
            player.SwitchCurrentActionMap("CharSelect");
            playerMovement.enabled = false;
            CharacterSelect.instance.onResetPlayer(player);

            Animator bodyAnimator = GetComponent<Animator>();
            Animator headAnimator = headToReplace.GetComponent<Animator>();
            bodyAnimator.SetBool("CharSelect", true);
            bodyAnimator.Play("CharSelect Idle", -1, 0);
            headAnimator.SetBool("CharSelect", true);
            headAnimator.Play("CharSelect Idle", -1, 0);

            PlayerSpawn.playerPrefabs[player.playerIndex] = null;
        }
    }

    void NewColor(string direction)
    {
        if (!ready)
        {
            if (direction == CharacterSelect.instance.nextColorString)
            {
                if (currentColor != CharacterSelect.instance.colorOptions.Length - 1)
                {
                    currentColor++;
                }
                else
                {
                    currentColor = 0;
                }
            }
            else if (direction == CharacterSelect.instance.previousColorString)
            {
                if (currentColor != 0)
                {
                    currentColor--;
                }
                else
                {
                    currentColor = CharacterSelect.instance.colorOptions.Length - 1;
                }
            }

            coloredImages = new Image[2];
            suitTransform = gameObject.FindComponentInChildWithTag<Transform>("Suit").transform;
            coloredImages = gameObject.GetComponentsInChildren<Image>();

            suitTransform.GetComponent<Renderer>().material = CharacterSelect.instance.colorOptions[currentColor];
            for (int i = 0; i < coloredImages.Length; i++)
            {
                Color emissColor = CharacterSelect.instance.colorOptions[currentColor].GetColor("_EmissionColor");
                coloredImages[i].GetComponent<Image>().color = emissColor;
            }

            // TODO: Finish materialization effect
            //suitTransform.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Materialization");
            //materializeEffect = suitTransform.gameObject.AddComponent<Materialize>();
            //materializeEffect.lerpAmount = 1.1f;
            //materializing = true;
        }
    }

    void NewHead(string direction)
    {
        if (!ready)
        {
            if (direction == CharacterSelect.instance.nextHeadString)
            {
                if (currentHead != CharacterSelect.instance.headOptions.Length - 1)
                {
                    currentHead++;
                }
                else
                {
                    currentHead = 0;
                }
            }
            else if (direction == CharacterSelect.instance.previousHeadString)
            {
                if (currentHead != 0)
                {
                    currentHead--;
                }
                else
                {
                    currentHead = CharacterSelect.instance.headOptions.Length - 1;
                }
            }

            GameObject newHead = Instantiate(CharacterSelect.instance.headOptions[currentHead], headToReplace.position, headToReplace.rotation, headToReplace.parent);
            Destroy(headToReplace.gameObject);
            headToReplace = newHead.transform;

            Animator bodyAnimator = GetComponent<Animator>();
            Animator headAnimator = newHead.GetComponent<Animator>();
            bodyAnimator.SetBool("CharSelect", true);
            bodyAnimator.Play("CharSelect Idle", -1, 0);
            headAnimator.SetBool("CharSelect", true);
            headAnimator.Play("CharSelect Idle", -1, 0);

            playerMovement.animators[1] = headAnimator;
        }
    }

    // TODO: Finish materialization effect
    //void Update()
    //{
    //    if (materializing)
    //    {
    //        materializeEffect.lerpAmount -= 0.2f * Time.deltaTime;

    //        if (materializeEffect.lerpAmount >= 1.0f)
    //        {
    //            suitTransform.GetComponent<Renderer>().material.shader = Shader.Find("Autodesk Interactive");
    //        }
    //    }
    //}
}
