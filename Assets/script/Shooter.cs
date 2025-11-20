using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject circlePrefab;   // Assign your projectile prefab
    public float shootForce = 8f;     // Speed of the projectile
    public float shootInterval = 3f;  // Time between shots

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(circlePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * shootForce;  // SHOOT SOUTH (DOWN)
    }
}
