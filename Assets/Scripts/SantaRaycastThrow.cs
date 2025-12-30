using UnityEngine;

public class SantaRaycastThrow : MonoBehaviour
{
    public float rayDistance = 15f;
    public LayerMask hitLayers;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // works on PC, Android, Web
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.up,
            rayDistance,
            hitLayers
        );

        Debug.DrawRay(transform.position, Vector2.up * rayDistance, Color.green, 0.3f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("House"))
            {
                GameManager.Instance.AddScore();
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("UpperBound"))
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}