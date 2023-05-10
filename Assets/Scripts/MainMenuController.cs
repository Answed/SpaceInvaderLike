using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MenuController
{
    [SerializeField] private TextMeshProUGUI titleText; //Title gets changed based on the selected Window
    [SerializeField] private GameObject[] mainMenuButtons; // Saves all Buttons on the Main Menu -> Because there are only Buttons the name is Buttons and not Objects
    [SerializeField] private GameObject[] creditsObjects; // Saves all Credits related objects
    [SerializeField] private GameObject[] settingsObjects;

    enum Window
    {
        Credits,
        Settings
    }

    private Window currentWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        SwitchWindow(mainMenuButtons, creditsObjects);
        titleText.text = "Credits";
        currentWindow = Window.Credits;
    }

    public void Settings()
    {
        SwitchWindow(mainMenuButtons, settingsObjects);
        titleText.text = "Settings";
        currentWindow = Window.Settings;
    }

    public void Back()
    {
        switch(currentWindow)
        {
            case Window.Credits:
                SwitchWindow(creditsObjects, mainMenuButtons);
                break;
            case Window.Settings:
                SwitchWindow(settingsObjects, mainMenuButtons);
                break;
        }
        titleText.text = "Space Invader Like";
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
