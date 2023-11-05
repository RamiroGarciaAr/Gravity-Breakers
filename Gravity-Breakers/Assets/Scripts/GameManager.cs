
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool gotGameOver = false;

    public float restartDelay = 0.4f;
    
    public  RespawnScreen respScreen;
    
    public void GameOver()
    {
        if (gotGameOver == false)
        {
            gotGameOver = true;
            Debug.Log("GAME OVER");
            Invoke("Restart",restartDelay);
        }
    }

    public void Restart()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
