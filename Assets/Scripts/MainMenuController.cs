using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
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
        DisableGameObjects(mainMenuButtons);
        titleText.text = "Credits";
        currentWindow = Window.Credits;
    }

    public void Back()
    {
        switch(currentWindow)
        {
            case Window.Credits:
                DisableGameObjects(creditsObjects);
                EnableGameObjects(mainMenuButtons);
                break;
            case Window.Settings:
                DisableGameObjects(settingsObjects);
                EnableGameObjects(mainMenuButtons);
                break;
        }
    }

    private void DisableGameObjects(GameObject[] objects)
    {
        foreach (GameObject _object in objects) _object.SetActive(false);  //_object because in C# object can't be the name of a variable
    }

    private void EnableGameObjects(GameObject[] objects)
    {
        foreach(GameObject _object in objects) _object.SetActive(true);
    }
}
