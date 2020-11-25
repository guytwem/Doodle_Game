using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;

    public void Awake()
    {
        LoadPlayerPrefs();// load player prefs on awake
    }

    public void Start()
    {
        Debug.Log("Starting game main menu"); // This is the first code called and logs the start of the game menu

        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false; // this starts in windowed, change to true and 1 for fullscreen start
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }

        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("Quality", 4);
            QualitySettings.SetQualityLevel(4);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }

        PlayerPrefs.Save();


    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");// loads game scene when play button pressed
    }



    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // loads main menu when button pressed
    }

    public void SetFullScreen(bool fullscreen) // for entering full screen and exiting
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeQuality(int index) // sets quality settings of the dropdown box
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void QuitGame() // this is our quit game function
    {
        Debug.Log("Quitting Game"); // Logs when the exit button is pressed
#if UNITY_EDITOR // This will quit playmode when we are in the game and the exit button is pressed
        EditorApplication.ExitPlaymode();
#endif 
        Application.Quit();


    }
    #region save and load player prefs
    public void SavePlayerPrefs() // saves player preferences for next load
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());

        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1); // 1 is bool for true
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0); // 0 bool for false
        }


        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("quality"))
        {
            int quality = PlayerPrefs.GetInt("quality");
            qualityDropdown.value = quality;
            if (QualitySettings.GetQualityLevel() != quality)
            {
                ChangeQuality(quality);
            }
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                fullscreenToggle.isOn = false;
            }
            else
            {
                fullscreenToggle.isOn = true; 
            }
        }
      
    }

    #endregion
}
