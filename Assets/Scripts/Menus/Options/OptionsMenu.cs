using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    PlayerController[] controlers;

    Image optionImage, lastOptionImage;

    public List<Image> menuImages = new List<Image>();
    [Space]
    public List<Sprite> highlightSprites = new List<Sprite>();

    int selectedOptionIndex, lastSelectedOption;

    bool selecting;


    void Start()
    {
        selectedOptionIndex = -1;
        controlers = FindObjectsOfType<PlayerController>();
        NextSetting();
    }

    void Update()
    {
        foreach (PlayerController controler in controlers)
        {
            controler.getInput();

            if (controler.movementVector.y < 0 && !selecting)
            {
                NextSetting();
            }

            if (controler.movementVector.y > 0 && !selecting)
            {
                PreviousSetting();
            }

            if (controler.movementVector.x < 0 && !selecting)
            {
                //NextOption();
            }

            if (controler.movementVector.x > 0 && !selecting)
            {
                //PreviousOption();
            }

            if (controler.pickUp && !selecting)
            {
                PressButton();
            }
        }
    }

    void NextSetting()
    {
        selecting = true;
        StartCoroutine(WaitForNextSelection());

        selectedOptionIndex++;
        if (selectedOptionIndex > menuImages.Count - 1)
        {
            selectedOptionIndex = 0;
        }
        lastSelectedOption = selectedOptionIndex - 1;
        if (lastSelectedOption < 0)
        {
            lastSelectedOption = menuImages.Count - 1;
        }

        lastOptionImage = menuImages[lastSelectedOption].GetComponent<Image>();
        optionImage = menuImages[selectedOptionIndex].GetComponent<Image>();

        if (lastOptionImage != null)
        {
            lastOptionImage.sprite = highlightSprites[0];
        }

        if (optionImage != null)
        {
            optionImage.sprite = highlightSprites[1];
        }
    }

    void PreviousSetting()
    {
        selecting = true;
        StartCoroutine(WaitForNextSelection());

        selectedOptionIndex--;
        if (selectedOptionIndex < 0)
        {
            selectedOptionIndex = menuImages.Count - 1;
        }
        lastSelectedOption = selectedOptionIndex + 1;
        if (lastSelectedOption > menuImages.Count - 1)
        {
            lastSelectedOption = 0;
        }

        lastOptionImage = menuImages[lastSelectedOption].GetComponent<Image>();
        optionImage = menuImages[selectedOptionIndex].GetComponent<Image>();

        if (lastOptionImage != null)
        {
            lastOptionImage.sprite = highlightSprites[0];
        }

        if (optionImage != null)
        {
            optionImage.sprite = highlightSprites[1];
        }
    }

    void PressButton()
    {
        if (menuImages[selectedOptionIndex].GetComponent<Button>())
        {
            if (!selecting)
            {
                menuImages[selectedOptionIndex].GetComponent<Image>().sprite = highlightSprites[2];
                menuImages[selectedOptionIndex].GetComponent<Button>().onClick.Invoke();
            }
        }
    }

    IEnumerator WaitForNextSelection()
    {
        yield return new WaitForSeconds(0.2f);
        selecting = false;
        yield return null;
    }
}
