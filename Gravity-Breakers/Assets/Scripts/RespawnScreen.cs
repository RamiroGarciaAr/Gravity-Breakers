using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScreen : MonoBehaviour
{
    public int timeing = 5;
    //public GameObject player;
    public Vector3 lastTriggerPosition;
   /* public void Setup()
    {
        gameObject.SetActive(true);
        Invoke("RestartButton",timeing);
    }*/

    /*public void RestartButton()
    {   
        player.gameObject.transform.position = lastTriggerPosition;
        gameObject.SetActive(false);
    }*/

    public void Quit()
    {
        Debug.Log("Quitting");
        SceneManager.LoadScene("HomeScreen");
    }
}
