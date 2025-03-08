using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 screenPosition;
    Vector3 worldPosition;


    public GameObject meleeAttack;
    public GameObject projectileTest;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            MeleeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ProjectileAttack();
        }
    }

    public void ProjectileAttack()
    {
        Debug.Log("Right Mouse Clicked");
        Instantiate(projectileTest, transform.position, transform.rotation);
    }

    public void MeleeAttack()
    {
        Vector3 direction = (worldPosition - transform.position).normalized;


        Instantiate(meleeAttack, transform.position + direction, transform.rotation);
    }

}


//forcing git commit