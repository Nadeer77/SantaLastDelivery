using UnityEngine;

public class House : MonoBehaviour
{
    public float speed = 2f;
    public float speedIncrease = 0.5f;

    public float leftLimit = -3f;
    public float rightLimit = 3f;

    private int direction = 1;
    private int lastSpeedIncreaseScore = 0;

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, 0);
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, 0);
            direction = 1;
        }
    }

    // This will be called from GameManager
    public void IncreaseSpeedIfNeeded(int score)
    {
        if (score % 5 == 0 && score != lastSpeedIncreaseScore)
        {
            speed += speedIncrease;
            lastSpeedIncreaseScore = score;
        }
    }
}
