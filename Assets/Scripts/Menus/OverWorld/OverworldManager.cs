using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct OverworldData
{
    [Header("Selected Level UI Elements")]
    public Image mapPreview;
    public TextMeshProUGUI levelName;
    public TextMeshProUGUI description;
    public Button launchButton;
    public Button cancelButton;

    // Constructor for the UI elements
    public OverworldData(Image _mapPreview, TextMeshProUGUI _levelName, TextMeshProUGUI _description, Button _launchButton, Button _cancelButton)
    {
        mapPreview = _mapPreview;
        levelName = _levelName;
        description = _description;
        launchButton = _launchButton;
        cancelButton = _cancelButton;
    }
}

public class OverworldManager : MonoBehaviour
{
    public static OverworldManager instance; // Singleton instance
    public OverworldData data; // Reference to the struct containing the constructor
    public LevelSelectController levelController; // For handling input
    PlayerController[] playerControllers;
    SelectedPlayer[] selectedPlayers;

    // Enum for handling selected level states
    public enum Level
    {
        Level1,
        Level2,
        Level3,
        Level4
    };

    [Header("Level Management")]
    [Space] public Level level;
    int selectedLevel = 1;
    public string charSelectSceneName;

    [Header("Overworld UI")]
    public Image[] levelObjects;
    public GameObject levelPanel;
    public TextMeshProUGUI levelSelectedText;
    public Sprite[] highlightSprites;
    public TextMeshProUGUI launchButtonText;

    [Header("Selected Level UI Pool")]
    public Sprite[] mapImages;
    public string[] levelNames;
    [TextArea(3, 10)] public string[] descriptions;

    // These should be fairly self-explanatory 
    bool ableToLaunch;
    bool selecting;


    #region Singleton
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    void Start ()
    {
        ableToLaunch = false;

        playerControllers = FindObjectsOfType<PlayerController>();

        selectedLevel = 1;
        level = Level.Level1;

        ApplyText();

        foreach (PlayerController player in playerControllers)
        {
            player.cameraTrans = Camera.main.transform;
        }
    }
	
	void Update ()
    {       
        GetInput(); // Checks for input to select a level
        selectedPlanet();
    }

    void selectedPlanet()
    {
        for(int i = 0; i < levelObjects.Length; i++)
        {
            if(i == selectedLevel - 1)
            {
                //levelObjects[i].gameObject.transform.localScale = new Vector3(1, 1, 1);
                levelObjects[i].sprite = highlightSprites[1];
            }
            else
            {
                //levelObjects[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                levelObjects[i].sprite = highlightSprites[0];
            }
        }
    }

    // See Update() for explanation
    void GetInput()
    {
        levelController.GetInput(); // Checks for input from the ship

        // Selection input
        if (levelController.pickUp && !ableToLaunch && !selecting)
        {
            selecting = true;
            StartCoroutine(SelectionDelay());

            levelObjects[selectedLevel - 1].sprite = highlightSprites[2];

            // Opens the mission panel UI
            SelectLevel();
        }

        // Directional movement input (RIGHT)
        if (levelController.movementVector.x > 0 && !ableToLaunch && !selecting)
        {
            selecting = true;
            StartCoroutine(SelectionDelay());

            // SUMMARY: If the player moves to another level, data needs to be updated
            switch (selectedLevel)
            {
                // If level 1 had been selected...
                case 1:
                    selectedLevel++;
                    level = Level.Level2;
                    break;
                // If level 2 had been selected...
                case 2:
                    selectedLevel++;
                    level = Level.Level3;
                    break;
                // If level 3 had been selected...
                case 3:
                    selectedLevel++;
                    level = Level.Level4;
                    break;
                // If level 4 had been selected...
                case 4:
                    selectedLevel = 1;
                    level = Level.Level1;
                    break;
            }

            // Updates the UI according to the new selected level
            DeactivatePanel();
            ApplyText();
        }

        // Directional movement input (LEFT)
        if (levelController.movementVector.x < 0 && !ableToLaunch && !selecting)
        {
            selecting = true;
            StartCoroutine(SelectionDelay());

            /// SUMMARY: If the player moves to another level, data needs to be updated
            switch (selectedLevel)
            {
                // If level 1 had been selected...
                case 1:
                    selectedLevel = 4;
                    level = Level.Level4;
                    break;
                // If level 2 had been selected...
                case 2:
                    selectedLevel--;
                    level = Level.Level1;
                    break;
                // If level 3 had been selected...
                case 3:
                    selectedLevel--;
                    level = Level.Level2;
                    break;
                case 4:
                    selectedLevel--;
                    level = Level.Level3;
                    break;
            }

            // Updates the UI according to the new selected level
            DeactivatePanel();
            ApplyText();
        }

        if (levelController.sprint && !ableToLaunch && !selecting)
        {
            selectedPlayers = FindObjectsOfType<SelectedPlayer>();

            selecting = true;
            StartCoroutine(SelectionDelay());

            foreach (SelectedPlayer player in selectedPlayers)
            {
                //player.gameObject.AddComponent<CharToDestroy>();
                Destroy(player.gameObject);
            }
            SceneFader.instance.FadeTo(charSelectSceneName);
        }
    }

    // Opens the mission panel UI
    public void SelectLevel()
    {
        ableToLaunch = true;
        levelPanel.SetActive(true);

        // Creates a new instance of the mission panel constructor
        OverworldData selectionPanel = new OverworldData(data.mapPreview, data.levelName, data.description, data.launchButton, data.cancelButton);

        // Switches the UI information depending on which level is selected
        switch (level)
        {
            // If it's level 1, set all UI elements to the first item in each array pool
            case Level.Level1:
                selectionPanel.mapPreview.sprite = mapImages[0];
                selectionPanel.levelName.text = levelNames[0];
                selectionPanel.description.text = descriptions[0];
                selectionPanel.launchButton.interactable = true;
                launchButtonText.text = "Launch";
                break;
            // If it's level 2, set all UI elements to the second item in each array pool
            case Level.Level2:
                selectionPanel.mapPreview.sprite = mapImages[1];
                selectionPanel.levelName.text = levelNames[1];
                selectionPanel.description.text = descriptions[1];
                selectionPanel.launchButton.interactable = true;
                launchButtonText.text = "Launch";
                break;
            // If it's level 3, set all UI elements to the third item in each array pool
            case Level.Level3:
                selectionPanel.mapPreview.sprite = mapImages[2];
                selectionPanel.levelName.text = levelNames[2];
                selectionPanel.description.text = descriptions[2];
                selectionPanel.launchButton.interactable = true;
                launchButtonText.text = "Launch";
                break;
            // If it's level 4, set all UI elements to the fourth item in each array pool
            case Level.Level4:
                selectionPanel.mapPreview.sprite = mapImages[3];
                selectionPanel.levelName.text = levelNames[3];
                selectionPanel.description.text = descriptions[3];
                selectionPanel.launchButton.interactable = true;
                launchButtonText.text = "Launch";
                break;
        }
    }

    // Closes the mission panel UI
    public void DeactivatePanel()
    {
        ableToLaunch = false;
        levelPanel.SetActive(false);
    }

    // Updates primary Overworld UI
    void ApplyText()
    {
        if (selectedLevel == 1)
        {
            levelSelectedText.text = "Tutorial";
        }
        else
        {
            levelSelectedText.text = "Level " + (selectedLevel - 1).ToString();
        }
    }

    IEnumerator SelectionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        selecting = false;
        yield return null;
    }
}
