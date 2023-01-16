using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer mixer;
    public TMP_Dropdown ResolutionDropdown;
    Resolution[] resolutions;
    private void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        int defaultResolutionId = 0;
        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                defaultResolutionId = i;
            }
        }

        ResolutionDropdown.AddOptions(resolutionOptions);
        ResolutionDropdown.value = defaultResolutionId;
        ResolutionDropdown.RefreshShownValue();
    }
    public void ChangeVolume(float volume)
    {
        mixer.SetFloat("masterVolume", volume);
    }
    public void ChangeQuality(int qualityId)
    {
        QualitySettings.SetQualityLevel(qualityId);
    }
    public void ChangeScreenSize(bool isMaximized)
    {
        Screen.fullScreen = isMaximized;
    }
    public void ChangeResolution(int resolutionID)
    {
        Resolution resolution = resolutions[resolutionID];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
