
using UnityEngine;

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

   /* public void Restart()
    {   
        respScreen.Setup();
    }
    public void Restart(Scene lastScene)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
