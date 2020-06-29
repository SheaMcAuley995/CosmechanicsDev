using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public List<string> options;

    Resolution[] resolutions;

    int rows;

    float width;
    float height;

    public Button prefab;
    Button button;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        options = new List<string>();

        int curResIndx = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = $" {resolutions[i].width} x {resolutions[i].height}";
            options.Add(option);

            if(resolutions[i].width  == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndx = i;
            }
        }

        RectTransform myRect = GetComponent<RectTransform>();

        rows = options.Count;

        height = myRect.rect.height / (float)rows;
        width = myRect.rect.width;

        GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(width, height);

        for(int i = 0; i < options.Count; i++)
        {
            button = (Button)Instantiate(prefab);
            button.transform.SetParent(transform, false);
        }
    }


    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int indx)
    {
        QualitySettings.SetQualityLevel(indx);
    }

    public void SetResolution(int resIndx)
    {
        Resolution resolution = resolutions[resIndx];

        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void setFullscreen(int indx)
    {
        switch(indx)
        {
            case 0 :

                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;

            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;

            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }


    }
}
