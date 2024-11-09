using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;   
    public GameObject optionsMenu;

    public Button resumeButton;
    public Button optionsButton;
    public Button saveQuitButton;

    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public Toggle fullscreenToggle;
    public Button applyButton;
    public Button backButton;
    public Button quitButtonInOptions;

    private bool isPaused = false;
    private float tempVolume;
    private float tempSensitivity;
    private bool tempFullscreen;

    void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

        LoadCurrentSettings();

        resumeButton.onClick.AddListener(ResumeGame);
        optionsButton.onClick.AddListener(ShowOptionsMenu);
        saveQuitButton.onClick.AddListener(SaveAndQuitGame);

        applyButton.onClick.AddListener(ApplySettings);
        backButton.onClick.AddListener(ShowPauseMenu);
        quitButtonInOptions.onClick.AddListener(SaveAndQuitGame);

        volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
        sensitivitySlider.onValueChanged.AddListener(HandleSensitivityChange);
        fullscreenToggle.onValueChanged.AddListener(HandleFullscreenToggle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        isPaused = true; 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false); 
        optionsMenu.SetActive(false); 
        isPaused = false; 
    }
    public void ShowOptionsMenu()
    {
        pauseMenu.SetActive(false); 
        optionsMenu.SetActive(true); 
    }

    public void ShowPauseMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void SaveAndQuitGame()
    {
        ApplySettings();

        Debug.Log("Game is quitting...");
        Application.Quit(); 

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ApplySettings()
    {
        AudioListener.volume = tempVolume;
        PlayerPrefs.SetFloat("volume", tempVolume);

        PlayerPrefs.SetFloat("sensitivity", tempSensitivity);

        Screen.fullScreen = tempFullscreen;
        PlayerPrefs.SetInt("fullscreen", tempFullscreen ? 1 : 0);

        PlayerPrefs.Save();

        Debug.Log("Settings Applied: Volume(" + tempVolume + "), Sensitivity(" + tempSensitivity + "), Fullscreen(" + tempFullscreen + ").");
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

    private void LoadCurrentSettings()
    {
        tempVolume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = tempVolume;

        tempSensitivity = PlayerPrefs.GetFloat("sensitivity", 1f);
        sensitivitySlider.value = tempSensitivity;

        tempFullscreen = PlayerPrefs.GetInt("fullscreen", Screen.fullScreen ? 1 : 0) == 1;
        fullscreenToggle.isOn = tempFullscreen;
    }
}