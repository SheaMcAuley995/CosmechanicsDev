using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
    // Used for detecting input from the controller
    Vector2 menuInput;

    // All of the buttons in the scene that the player can select
    [SerializeField] List<Button> menuButtons = new List<Button>();
    [Space]
    // The different button sprites for normal, highlighted, and pressed
    [SerializeField] List<Sprite> highlightSprites = new List<Sprite>();

    // The image component attached to the currently selected button &
    // the previously selected button. Used to access & change their sprite,
    // referenced above.
    Image selectedButtonImage, previousButtonImage;

    // The indexes of the currently selected button & the previously 
    // selected button. 
    int selectedButtonIndex, previousButtonIndex;

    // Used to prevent axis input from flying through the entire menu
    bool selecting = false;


    void Start()
    {
        selectedButtonIndex = -1;
        SelectNextButton();
    }

    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        Vector3 input = new Vector3(menuInput.x, menuInput.y, 0f);

        // If stick moves down
        if (menuInput.y < 0f && !selecting)
        {
            SelectNextButton();
        }

        // If stick moves up
        if (menuInput.y > 0f && !selecting)
        {
            SelectPreviousButton();
        }
    }

    void SelectNextButton()
    {
        selecting = true;
        StartCoroutine(DelayForNextSelection());

        /// <summary>
        /// In order: selects the next button in the list and loops to top if
        /// the selected button is greater than # of buttons, gets the selected button's
        /// image component, and sets it to the highlighted button sprite [1].
        /// </summary>
        #region Selected Button
        selectedButtonIndex++;
        if (selectedButtonIndex > menuButtons.Count - 1)
        {
            selectedButtonIndex = 0;
        }

        selectedButtonImage = menuButtons[selectedButtonIndex].GetComponent<Image>();
        selectedButtonImage.sprite = highlightSprites[1];
        #endregion

        /// <summary>
        /// In order: sets the previously selected button and loops it to bottom
        /// if it's less than button 0, gets the previously selected button's
        /// image component, and sets it to the normal button sprite [0].
        /// </summary>
        #region Previously Selected Button
        previousButtonIndex = selectedButtonIndex - 1;
        if (previousButtonIndex < 0)
        {
            previousButtonIndex = menuButtons.Count - 1;
        }
        previousButtonImage = menuButtons[previousButtonIndex].GetComponent<Image>();
        previousButtonImage.sprite = highlightSprites[0];
        #endregion
    }

    void SelectPreviousButton()
    {
        selecting = true;
        StartCoroutine(DelayForNextSelection());

        /// <summary>
        /// In order: selects the previous button in the list and loops to bottom if
        /// the selected button is less than top button, gets the selected button's
        /// image component, and sets it to the highlighted button sprite [1].
        /// </summary>
        #region Selected Button
        selectedButtonIndex--;
        if (selectedButtonIndex < 0)
        {
            selectedButtonIndex = menuButtons.Count - 1;
        }

        selectedButtonImage = menuButtons[selectedButtonIndex].GetComponent<Image>();
        selectedButtonImage.sprite = highlightSprites[1];
        #endregion

        /// <summary>
        /// In order: sets the previously selected button and loops it to top
        /// if it's greater than # of buttons, gets the previously selected button's
        /// image component, and sets it to the normal button sprite [0].
        /// </summary>
        #region Previously Selected Button
        previousButtonIndex = selectedButtonIndex + 1;
        if (previousButtonIndex > menuButtons.Count - 1)
        {
            previousButtonIndex = 0;
        }
        previousButtonImage = menuButtons[previousButtonIndex].GetComponent<Image>();
        previousButtonImage.sprite = highlightSprites[0];
        #endregion
    }

    void PressButton()
    {
        // If the button is clickable
        if (menuButtons[selectedButtonIndex].interactable)
        {
            // Sets the button image's sprite to pressed [2], and invokes the
            // button's onClick function.
            menuButtons[selectedButtonIndex].GetComponent<Image>().sprite = highlightSprites[2];
            menuButtons[selectedButtonIndex].onClick.Invoke();
        }
    }

    IEnumerator DelayForNextSelection()
    {
        yield return new WaitForSeconds(0.2f);
        selecting = false;
        yield return null;
    }

    #region Input Manager Functions
    void OnNavigateMenu(InputValue value)
    {
        menuInput = value.Get<Vector2>();
    }

    void OnSelectButton()
    {
        PressButton();
    }
    #endregion
}
