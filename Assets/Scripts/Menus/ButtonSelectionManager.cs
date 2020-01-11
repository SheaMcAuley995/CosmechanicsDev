using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectionManager : MonoBehaviour
{
    PlayerController[] controlers;
    LevelSelectController levelController;

    Image buttonImage, lastButtonImage;

    public List<Button> menuButtons = new List<Button>();
    [Space]
    //public List<Image> buttonSelectors = new List<Image>();
    //[Space]
    public List<Sprite> highlightSprites = new List<Sprite>();

    int selectedButtonIndex, lastSelectedButton;

    bool selecting, ableToGetInput;
    string currentScene;


    IEnumerator Start()
    {
        ableToGetInput = false;
        selectedButtonIndex = -1;
        yield return new WaitForSeconds(0.2f);
        controlers = FindObjectsOfType<PlayerController>();
        levelController = FindObjectOfType<LevelSelectController>();
        ableToGetInput = true;
        currentScene = SceneManager.GetActiveScene().name;
        SelectButtonDownward();
    }

    void Update()
    {
        if (ableToGetInput && currentScene != "CacieOverworld")
        {
            foreach (PlayerController controler in controlers)
            {
                controler.getInput();

                if (controler.movementVector.y < 0 && !selecting)
                {
                    SelectButtonDownward();
                }

                if (controler.movementVector.y > 0 && !selecting)
                {
                    SelectButtonUpward();
                }

                if (controler.pickUp && !selecting)
                {
                    PressButton();
                }
            }
        }

        if (ableToGetInput && currentScene == "CacieOverworld")
        {
            levelController.GetInput();

            if (levelController.movementVector.y < 0 && !selecting)
            {
                SelectButtonDownward();
            }

            if (levelController.movementVector.y > 0 && !selecting)
            {
                SelectButtonUpward();
            }

            if (levelController.pickUp && !selecting)
            {
                PressButton();
            }
        }
    }

    void SelectButtonDownward()
    {
        selecting = true;
        StartCoroutine(WaitForNextSelection());

        selectedButtonIndex++;
        if (selectedButtonIndex > menuButtons.Count - 1)
        {
            selectedButtonIndex = 0;
        }
        lastSelectedButton = selectedButtonIndex - 1;
        if (lastSelectedButton < 0)
        {
            lastSelectedButton = menuButtons.Count - 1;
        }

        //lastSelector = buttonSelectors[lastSelectedButton].GetComponent<Image>();
        //selector = buttonSelectors[selectedButtonIndex].GetComponent<Image>();
        lastButtonImage = menuButtons[lastSelectedButton].GetComponent<Image>();
        buttonImage = menuButtons[selectedButtonIndex].GetComponent<Image>();

        if (lastButtonImage != null)
        {
            lastButtonImage.sprite = highlightSprites[0];
        }

        if (buttonImage != null)
        {
            buttonImage.sprite = highlightSprites[1];
        }
    }

    void SelectButtonUpward()
    {
        selecting = true;
        StartCoroutine(WaitForNextSelection());

        selectedButtonIndex--;
        if (selectedButtonIndex < 0)
        {
            selectedButtonIndex = menuButtons.Count - 1;
        }
        lastSelectedButton = selectedButtonIndex + 1;
        if (lastSelectedButton > menuButtons.Count - 1)
        {
            lastSelectedButton = 0;
        }

        //lastSelector = buttonSelectors[lastSelectedButton].GetComponent<Image>();
        //selector = buttonSelectors[selectedButtonIndex].GetComponent<Image>();
        lastButtonImage = menuButtons[lastSelectedButton].GetComponent<Image>();
        buttonImage = menuButtons[selectedButtonIndex].GetComponent<Image>();

        if (lastButtonImage != null)
        {
            lastButtonImage.sprite = highlightSprites[0];
        }

        if (buttonImage != null)
        {
            buttonImage.sprite = highlightSprites[1];
        }
    }

    void PressButton()
    {
        if (menuButtons[selectedButtonIndex].interactable && !selecting)
        {
            //selecting = true;
            //StartCoroutine(WaitForNextSelection());

            menuButtons[selectedButtonIndex].GetComponent<Image>().sprite = highlightSprites[2];
            menuButtons[selectedButtonIndex].onClick.Invoke();
        }
    }

    IEnumerator WaitForNextSelection()
    {
        yield return new WaitForSeconds(0.2f);
        selecting = false;
        yield return null;
    }
}
