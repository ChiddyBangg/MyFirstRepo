using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;

    private float timer;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }
}
