using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class QuickButtonManager : MonoBehaviour
{
    public GameObject firePrefab; // GET RID OF THIS

    public PlayerInput playerInput;
    [Space]
    public ButtonCanvasView canvasView;
    [Space]
    public Image image;
    [Space]
    public List<Sprite> buttonSprites = new List<Sprite>();

    [SerializeField] string playerTag = "Char";

    [Space]

    [Range(1, 10)]
    public int requiredSuccessfulAttempts = 6;

    [Range(0f, 2f)]
    public float timeBetweenButtons = 0.65f;

    int index;
    int successfulEntries = 0;


    public CameraMultiTarget cameraMultiTarget;
    public Vector3[] spawnPoints;
    private void Start()
    {
        PlayerSpawn spawner = new PlayerSpawn(spawnPoints, cameraMultiTarget);
    }

    void OnTriggerEnter(Collider other)
    {
        successfulEntries = 0;

        if (other.gameObject.CompareTag(playerTag))
        {
            GenerateRandomButton();
            playerInput.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        successfulEntries = 0;

        if (other.gameObject.CompareTag(playerTag))
        {
            canvasView.ToggleImages(false);
            playerInput.enabled = false;
        }
    }

    void GenerateRandomButton()
    {
        canvasView.ToggleImages(true);

        // 0 = Y, 1 = A, 2 = X, 3 = B, 4 = LB, 5 = RB
        index = Random.Range(0, buttonSprites.Count);
        image.sprite = buttonSprites[index];
    }

    bool CorrectIndex(int generatedNumber)
    {
        if (index == generatedNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region Input Manager Functions
    void OnPressedNorthButton() // index 0
    {
        if (CorrectIndex(0)) // If you press this button and it is the correct button to press
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else // if you've completed all of the buttons in the sequence
            {
                EnteredAllButtons();
            }
        }
        else // if you press this button but it's not the correct button to press
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }
    void OnPressedSouthButton() // index 1
    {
        if (CorrectIndex(1))
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else
            {
                EnteredAllButtons();
            }
        }
        else
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }

    void OnPressedWestButton()
    {
        if (CorrectIndex(2))
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else
            {
                EnteredAllButtons();
            }
        }
        else
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }

    void OnPressedEastButton()
    {
        if (CorrectIndex(3))
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else
            {
                EnteredAllButtons();
            }
        }
        else
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }

    void OnPressedLeftShoulder()
    {
        if (CorrectIndex(4))
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else
            {
                EnteredAllButtons();
            }
        }
        else
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }

    void OnPressedRightShoulder()
    {
        if (CorrectIndex(5))
        {
            successfulEntries++;

            if (successfulEntries < requiredSuccessfulAttempts)
            {
                StartCoroutine(DisplayResult(true, false));
            }
            else
            {
                EnteredAllButtons();
            }
        }
        else
        {
            successfulEntries = 0;
            StartCoroutine(DisplayResult(false, false));
        }
    }
    #endregion

    void EnteredAllButtons()
    {
        StartCoroutine(DisplayResult(true, true));
    }

    IEnumerator DisplayResult(bool correctButton, bool sequenceCompleted)
    {
        if (correctButton)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
        }

        yield return new WaitForSeconds(timeBetweenButtons);

        image.color = Color.white;

        if (!sequenceCompleted)
        {
            GenerateRandomButton();
        }
        else
        {
            firePrefab.SetActive(true);

            successfulEntries = 0;
            canvasView.ToggleImages(false);
            playerInput.enabled = false;
        }

        yield return null;
    }
}
