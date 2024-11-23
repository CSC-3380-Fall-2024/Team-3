using UnityEngine;
using UnityEngine.UI; // Ensure this is included for handling UI components
using UnityEngine.SceneManagement; // For scene switching

public class EndScreen : MonoBehaviour
{
    public Text scoreText; // Reference to the Unity Text component for score display

    void Start()
    {
        // Retrieve and display the player's score
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = "Your Score: " + playerScore.ToString();
    }

    // Method to restart the game from the beginning
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene"); // Replace with your main game scene name
    }

    // Method to return to the main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene"); // Replace with your main menu scene name
    }

    // Method to quit the game (only works in built applications)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // To show something happens in the editor, since quit won't work in testing.
    }
}