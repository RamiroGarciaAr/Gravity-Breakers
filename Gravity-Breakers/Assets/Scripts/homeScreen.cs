using UnityEngine;
using UnityEngine.SceneManagement;
public class homeScreen: MonoBehaviour
{
    public void stage1Go()
    {
        Debug.Log("Go To Stage1");
        SceneManager.LoadScene("ACA VA EL NOMBRE");
    }
}