using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    

    public void PlayerDied()
    {
       
        GameOver();
        Debug.Log("player died game controller script is working");
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
       
    }
    public void Restart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
