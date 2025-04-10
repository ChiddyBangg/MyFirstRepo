using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 screenPosition;
    Vector3 worldPosition;
    public GameObject projectileTest;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ProjectileAttack();
        }
    }

    public void ProjectileAttack()
    {
        Instantiate(projectileTest, transform.position, transform.rotation);
    }

}


//forcing git commit