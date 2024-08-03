using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float speed = 2f; // Speed at which the pickup moves down the screen
    public Color flashColor = Color.yellow; // Color to flash for the pickup
    public float flashInterval = 0.5f; // Interval for flashing color

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        InvokeRepeating("FlashColor", flashInterval, flashInterval);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f) // Assuming the lower boundary of the screen is at y = -6
        {
            Destroy(gameObject);
        }
    }

    private void FlashColor()
    {
        if (spriteRenderer.color == originalColor)
        {
            spriteRenderer.color = flashColor;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.CollectPickup();
                Destroy(gameObject);
            }
        }
    }
}
