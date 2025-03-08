using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerHealth == null){
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
