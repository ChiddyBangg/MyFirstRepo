using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ProjectileLogic : MonoBehaviour
{
    Vector3 screenPosition;
    Vector3 worldPosition;
    public float moveSpeed = 5f;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    }

    // Update is called once per frame
    void Update()
    {


        direction = (worldPosition - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.position += transform.position * moveSpeed * Time.deltaTime;
       //transform.Translate((transform.forward * moveSpeed * Time.deltaTime));

    }
}
