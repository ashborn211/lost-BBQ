using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private int maxHealth = 3;

    private int health;

    public Slider healthSlider;

    public Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        health = maxHealth;

        healthText.text = health.ToString();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput, 1).normalized * speed;

        rb.linearVelocity = movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Triggered by Enemy");

            health -= 1;
            UpdateHealth();

            if (health <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    void UpdateHealth()
    {
        healthText.text = health.ToString();
        healthSlider.value = health;
    }
}
