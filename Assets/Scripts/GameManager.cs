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
    public bool isGameOver = false;


    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
        UpdateScore();
    }

    public void AddScore(int value)
    {
        score += value;
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
        if (isGameOver) return;

        isGameOver = true;
        gameOverPanel.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}