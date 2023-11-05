
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RespawnScreen : MonoBehaviour
{
    public int timeing = 5;

    public  TMP_Text textToDisplay;

    public GameObject player;
    public Vector3 lastTriggerPosition;
    public void Setup()
    {
        gameObject.SetActive(true);
        textToDisplay.text ="Reset in" + timeing;
        Invoke("RestartButton",timeing);
    }

    public void RestartButton()
    {   
        player.gameObject.transform.position = lastTriggerPosition;
        gameObject.SetActive(false);
    }
}
