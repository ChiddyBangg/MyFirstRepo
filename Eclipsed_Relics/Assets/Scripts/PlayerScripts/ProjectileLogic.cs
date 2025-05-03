using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ProjectileLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force = 5f;
    private float timer;
    [SerializeField] private int damage = 10; // Added damage value

    // Start is called before the first frame update
    void Start()
    {
        // applies force to the rigidbody of the bullet to make it move at a constant speed
        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePosition - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        // bullet - time to live
        timer += Time.deltaTime;
        if (timer > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy the projectile upon impact
        }
    }
}