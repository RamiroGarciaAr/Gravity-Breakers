using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            getHit();
        }
    }

    private void getHit()
    {
        Debug.Log("ouch");
        health -= 25f;
        if (health == 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
