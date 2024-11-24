using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class EndScreen : MonoBehaviour
{
    public TMP_Text scoreText; 
    public Button NewGameButton;
    public Button MainMenuButton;
    public Button QuitGameButton;

    void Start()
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Your Score: " + playerScore.ToString();
        NewGameButton.onClick.AddListener(RestartGame);
        MainMenuButton.onClick.AddListener(GoToMainMenu);
        QuitGameButton.onClick.AddListener(QuitGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); 
    }
}