using System.Threading;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;



    //Timer for game
    [SerializeField] private float timer = 0;
    [SerializeField] private TextMeshProUGUI timerText;



    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        int seconds = Convert.ToInt32(timer % 60);
        timerText.text = seconds.ToString();
    }


    [SerializeField] private TMP_Text gameOverText;

    int finalCount = 0;

    public void PlayerDied()
    {

        GameOver();
        Debug.Log("player died game controller script is working");
    }
    public void PlayerWon()
    {
        gameOverText.text = "You Win!";
        GameOverPanel.SetActive(true);


    }
    public void EnemyCount(int count)
    {
        
        finalCount += count;
        Debug.Log(finalCount);

        if (finalCount >= 3)
        {
            PlayerWon();
        }
    }
    public void GameOver()
    {
        gameOverText.text = "You Died!";
        GameOverPanel.SetActive(true);

    }
    public void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
