using System;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject rangedUnit;
    [SerializeField] private GameObject meleeUnit;
    [SerializeField] private GameObject slowUnit;


    private float timer = 0;
    private bool spawnCheck = true;

    private int spawnAmount = 5;

    private void FixedUpdate()
    {

        timer += Time.deltaTime;
        int seconds = Convert.ToInt32(timer % 60);

        if (seconds % 10 == 0 && spawnCheck == true)
        {
            SpawnEnemy(2);
            spawnCheck = false;
        }
    }

    public void SpawnEnemy(int spawnValue)
    {
        for (int i = 0; i < spawnAmount + 1; i++)
        {
            switch (spawnValue)
            {
                case 0:
                    Instantiate(rangedUnit);
                    break;
                case 1:
                    Instantiate(meleeUnit);
                    break;
                case 2:
                    Instantiate(slowUnit);
                    break;
                case 3:
                    break;
                default:
                    Debug.Log("Could not spawn, error occurred");
                    break;
            }
        }
        
    }
}
