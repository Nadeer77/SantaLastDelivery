using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public House houseMove;

    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
        UpdateScore();
    }

    public void AddScore()
    {
        score++;
        UpdateScore();

        // Increase house speed every 5 points
        houseMove.IncreaseSpeedIfNeeded(score);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}