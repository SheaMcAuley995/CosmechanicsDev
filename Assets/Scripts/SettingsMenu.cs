using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

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

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResIndx;
        resolutionDropdown.RefreshShownValue();
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
