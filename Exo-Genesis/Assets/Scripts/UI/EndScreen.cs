using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class EndScreen : MonoBehaviour
{
    public TMP_Text scoreText; 
    public Button NewGameButton;
    
    public Button MainMenuButton;

    public Button QuitButton;

    void Start()
    {
        // Retrieve and display the player's score
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Your Score: " + playerScore.ToString();
        NewGameButton.onClick.AddListener(RestartGame);
        MainMenuButton.onClick.AddListener(GoToMainMenu);
        QuitButton.onClick.AddListener(QuitGame);
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