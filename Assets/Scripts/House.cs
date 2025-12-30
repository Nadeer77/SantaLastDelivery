using UnityEngine;

public class House : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if (transform.position.x > 2f || transform.position.x < -2f)
        {
            direction *= -1;
        }
    }

    public void IncreaseSpeed()
    {
        speed += 0.3f;
    }
}