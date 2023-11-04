using UnityEngine;

public class Button : MonoBehaviour
{
    public bool open = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            open = true;
            Destroy(gameObject);
        }
    }
}