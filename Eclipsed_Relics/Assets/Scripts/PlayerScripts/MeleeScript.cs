using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int damage;
    [SerializeField] private Collider2D meleeCollider; // Collider for melee hitbox
    float timeUntilMelee;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Melee Attack - Does attack animation on mouse button 1 click with delay of meleeSpeed
        if(timeUntilMelee <= 0f) {
            if(Input.GetMouseButtonDown(0)) {
                anim.SetTrigger("MeleeStrike");
                timeUntilMelee = meleeSpeed;
                meleeCollider.enabled = true;
            }
        } else {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy") {
            collision.GetComponent<EnemyHealth>().TakeDamage((int)damage);
        }
    }
 }
