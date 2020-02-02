using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropDown;

    public PauseMenu pause;

    Resolution[] resolutions;

    // Start is called before the first frame update
    private void Start()
    {       
        Debug.Log("Current resolution = " + Screen.currentResolution.width + " x " + Screen.currentResolution.height);
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Current resolution = " + Screen.currentResolution.width + " x " + Screen.currentResolution.height);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Debug.Log("Fullscreen is " + isFullscreen);
        Screen.fullScreen = isFullscreen;
    }
}

//resolutions = Screen.resolutions;

//resolutionDropDown.ClearOptions();

//List<string> options = new List<string>();

//int currentResolutionIndex = 0;

//for (int i = 0; i < resolutions.Length; i++)
//{
//    string option = resolutions[i].width + "x" + resolutions[i].height;
//    options.Add(option);

//    if (resolutions[i].width == Screen.width &&
//        resolutions[i].height == Screen.height)
//    {
//        currentResolutionIndex = i;
//    }
//}

//resolutionDropDown.AddOptions(options);
//resolutionDropDown.value = currentResolutionIndex;
//resolutionDropDown.RefreshShownValue();
