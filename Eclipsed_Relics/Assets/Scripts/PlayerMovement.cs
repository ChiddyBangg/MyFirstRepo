using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //sets the players movement speed rate/value
    float moveSpeed = 5;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the keyboard for horizontal (A/D or Left/Right) and vertical (W/S or Up/Down) movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Change the position of the palyer object based on the input and speed
        transform.position += move * moveSpeed * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprint activated");
        }

        if (transform.rotation.z < 0) 
        {
            Debug.Log("Rotation less than 0");
        }
        else if (transform.rotation.z > 0){
            Debug.Log("Rotaton Greater than");
        }
        else
        {
            Debug.Log("Rotation is 0");
        }

    }
}
