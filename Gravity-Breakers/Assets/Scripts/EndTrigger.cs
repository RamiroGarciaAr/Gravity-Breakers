using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Chase player");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinningScreen");
        }
    }
}