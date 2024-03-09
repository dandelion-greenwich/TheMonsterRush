using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer SFXMixer;
    public AudioMixer MusicMixer;
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;

    private void Start()
    {
        resolutions = Screen.resolutions;

        // Clear out all the options in the resolutions dropdown
        resolutionDropdown.ClearOptions();

        // Create a list of strings for our options
        List<string> options = new List<string>();

        //This allows the dropdown menu to start on the correct resolution
        int currentResolutionIndex = 0;
        // Loop through each element in the resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Create a string that displays our resolutions
            string option = resolutions[i].width + " x " + resolutions[i].height;

            // we add that string to the options list
            options.Add(option);

            /* This compares the current width and the height 
             * and if they match up it stores the index */
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        // We add the option list to the resolution dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("Volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
