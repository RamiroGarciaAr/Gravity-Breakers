
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
        Invoke("RestartButton",2f);
    }

    public void RestartButton()
    {   
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
