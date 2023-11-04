
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RespawnScreen : MonoBehaviour
{
    public int timeing = 5;

    public  TMP_Text textToDisplay;
    public void Setup()
    {
        gameObject.SetActive(true);
        textToDisplay.text ="Reset in" + timeing.ToString();
        Invoke("RestartButton",timeing);
    }

    public void RestartButton()
    {   
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
