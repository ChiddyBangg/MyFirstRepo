using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RangedMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
        }
        else if (distance < 8)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
