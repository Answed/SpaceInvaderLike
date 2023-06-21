using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MenuController
{
    [SerializeField] private TextMeshProUGUI titleText; //Title gets changed based on the selected Window
    [SerializeField] private GameObject[] mainMenuButtons; // Saves all Buttons on the Main Menu -> Because there are only Buttons the name is Buttons and not Objects
    [SerializeField] private GameObject[] creditsObjects; // Saves all Credits related objects
    [SerializeField] private GameObject[] settingsObjects;
    [SerializeField] private GameObject[] upgradeObjects;
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider effectVolume;

    enum Window
    {
        Upgrade,
        Settings,
        Credits
    }

    private Window currentWindow;
    private UpgradeShopManager upgradeShopManager;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        upgradeShopManager = GetComponent<UpgradeShopManager>();
        audioManager = GameObject.Find("AudiManager").GetComponent<AudioManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void UpgradeShop()
    {
        SwitchWindow(mainMenuButtons, upgradeObjects);
        titleText.text = "Upgrades";
        upgradeShopManager.LoadShop();
        currentWindow = Window.Upgrade;
    }
    public void Settings()
    {
        SwitchWindow(mainMenuButtons, settingsObjects);
        titleText.text = "Settings";
        currentWindow = Window.Settings;
    }

    public void Credits()
    {
        SwitchWindow(mainMenuButtons, creditsObjects);
        titleText.text = "Credits";
        currentWindow = Window.Credits;
    }

    // Changes back to MainMenu
    public void Back()
    {
        switch(currentWindow)
        {
            case Window.Upgrade:
                SwitchWindow(upgradeObjects, mainMenuButtons);
                upgradeShopManager.CloseShop();
                break;
            case Window.Settings:
                SwitchWindow(settingsObjects, mainMenuButtons);
                audioManager.UpdateSoundVolume(musicVolume.value, effectVolume.value);
                break;
            case Window.Credits:
                SwitchWindow(creditsObjects, mainMenuButtons);
                break;
        }
        titleText.text = "Space Invader Like";
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
