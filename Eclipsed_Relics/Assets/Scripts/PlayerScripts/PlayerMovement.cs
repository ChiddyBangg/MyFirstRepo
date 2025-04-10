
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Sets the player's movement speed rate/value
    float moveSpeed = 5;

    private Rigidbody2D rb;  // Reference to Rigidbody2D component

    private bool rotationLock;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation of player
        // Get the position of the mouse on the screen
        if (timer <= 0)
        {
            rotationLock = false;
            if (!rotationLock)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                    Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
                    transform.up = direction;
                    rotationLock = true;
                    timer = 0.5f;
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

        // Get input from the keyboard for horizontal (A/D or Left/Right) and vertical (W/S or Up/Down) movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Change the position of the player object based on the input and speed
        transform.position += move * moveSpeed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprint activated");
        }

    }
}
