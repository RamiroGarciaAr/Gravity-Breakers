using UnityEngine;


public class RespawnScreen : MonoBehaviour
{
    
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
        //SceneManager.LoadScene("HomeScreen");
    }
}
