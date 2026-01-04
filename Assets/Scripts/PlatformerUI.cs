using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class PlatformerUI : MonoBehaviour
{

    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject DisplayPanel;
    [SerializeField] TMP_Dropdown ResolutionsDropdown;
    private Resolution[] resolutions;
    [SerializeField] TextMeshProUGUI topText;


    private void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        Debug.Log("hi1");

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if (!options.Contains(option))
            {
                options.Add(option);
            }

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        Debug.Log("HI2");

        ResolutionsDropdown.AddOptions(options);
        ResolutionsDropdown.value = currentResolutionIndex;
        ResolutionsDropdown.RefreshShownValue();



    }

    public void LoadSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        topText.text = "Settings";
    }

    public void LoadDisplay()
    {
        SettingsPanel.SetActive(false);
        DisplayPanel.SetActive(true);
        topText.text = "Display";

    }

    public void StartGame()
    {
        
    }

    public void Exit()
    {
        Application.Quit();


        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }

    public void Return(string btnName)
    {
        if(btnName == "Settings")
        {
            SettingsPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
            topText.text = "Main Menu";
        }
        else if (btnName == "Display" ||  btnName == "Audio")
        {
           DisplayPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }
}
