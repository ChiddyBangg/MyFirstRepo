using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time > 1)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
}
