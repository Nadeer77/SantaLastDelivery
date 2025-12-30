using UnityEngine;

public class SantaRaycastThrow : MonoBehaviour
{
    public Transform rayOrigin;          // Santa / hand position
    public float rayDistance = 20f;       // How far the ray goes
    public LayerMask houseLayer;          // Assign House layer

    private bool canScore = true;         // 🔒 Safety lock

    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        bool isPressed =
    #if UNITY_EDITOR
            Input.GetMouseButtonDown(0);
    #else
            Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    #endif

        if (isPressed)
        {
            ShootRay();
        }
    }


    // ✅ Unified input (Editor + Android + WebGL)
    bool IsTap()
    {
        if (Input.GetMouseButtonDown(0))
            return true;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    void ShootRay()
    {
        // 🔒 Prevent multiple hits from same tap
        if (!canScore)
            return;

        RaycastHit2D hit = Physics2D.Raycast(
            rayOrigin.position,
            Vector2.up,
            rayDistance,
            houseLayer
        );

        // (Optional) Debug ray
        Debug.DrawRay(rayOrigin.position, Vector2.up * rayDistance, Color.green, 0.2f);

        if (hit.collider != null)
        {
            int hitLayer = hit.collider.gameObject.layer;

            // 🎯 HIT HOUSE
            if (hitLayer == LayerMask.NameToLayer("House"))
            {
                canScore = false;
                GameManager.Instance.AddScore(1);
                Invoke(nameof(ResetScoreLock), 0.1f);
            }
            // ❌ HIT UPPER BOUND
            else if (hitLayer == LayerMask.NameToLayer("UpperBound"))
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            // ❌ HIT NOTHING
            GameManager.Instance.GameOver();
        }
    }

    void ResetScoreLock()
    {
        canScore = true;
    }
}
