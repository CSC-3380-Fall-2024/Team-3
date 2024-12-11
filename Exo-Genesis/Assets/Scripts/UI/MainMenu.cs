using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;

    public Button newGameButton;
    public Button optionsButton;
    public Button quitButtonMainMenu;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public Toggle fullscreenToggle;
    public Button applyButton;
    public Button backButton;
    public Button quitButtonOptionsMenu;

    private float tempVolume;
    private float tempSensitivity;
    private bool tempFullscreen;

    void Start()
    {
        ShowMainMenu();

        LoadCurrentSettings();
        PlayerPrefs.SetInt("PlayerScore", 0);
        newGameButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(ShowOptionsMenu);
        quitButtonMainMenu.onClick.AddListener(QuitGame);

        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
        sensitivitySlider.onValueChanged.AddListener(HandleSensitivityChange);
        fullscreenToggle.onValueChanged.AddListener(HandleFullscreenToggle);

        applyButton.onClick.AddListener(ApplySettings);
        backButton.onClick.AddListener(ShowMainMenu);
        quitButtonOptionsMenu.onClick.AddListener(QuitGame);
    }

    public void ShowMainMenu()
    {
        mainMenuCanvas.enabled = true;
        optionsMenuCanvas.enabled = false;
    }

    public void ShowOptionsMenu()
    {
        mainMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
    }

    void LoadCurrentSettings()
    {
        tempVolume = PlayerPrefs.GetFloat("volume", AudioListener.volume);
        volumeSlider.value = tempVolume;

        tempSensitivity = PlayerPrefs.GetFloat("sensitivity", 1f); 
        sensitivitySlider.value = tempSensitivity;

        tempFullscreen = PlayerPrefs.GetInt("fullscreen", Screen.fullScreen ? 1 : 0) == 1;
        fullscreenToggle.isOn = tempFullscreen;
    }

    public void HandleVolumeChange(float volume)
    {
        tempVolume = volume;
    }

    public void HandleSensitivityChange(float sensitivity)
    {
        tempSensitivity = sensitivity;
    }

    public void HandleFullscreenToggle(bool isFullscreen)
    {
        tempFullscreen = isFullscreen;
    }

    public void ApplySettings()
    {
        AudioListener.volume = tempVolume;
        PlayerPrefs.SetFloat("volume", tempVolume);

        PlayerPrefs.SetFloat("sensitivity", tempSensitivity);

        Screen.fullScreen = tempFullscreen;
        PlayerPrefs.SetInt("fullscreen", tempFullscreen ? 1 : 0);

        PlayerPrefs.Save();

        Debug.Log("Settings Applied: Volume(" + tempVolume + "), Sensitivity(" + tempSensitivity + "), Fullscreen(" + tempFullscreen + ")");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}