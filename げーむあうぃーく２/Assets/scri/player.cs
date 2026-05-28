using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 startMousePos;
    private Vector2 endMousePos;

    public float power = 10f;

    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startMousePos =
                cam.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            endMousePos =
                cam.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue()
                );

            Vector2 direction = startMousePos - endMousePos;

            rb.linearVelocity = direction * power;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}