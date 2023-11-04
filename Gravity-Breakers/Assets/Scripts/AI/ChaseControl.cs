
using UnityEngine;
public class ChaseControl : MonoBehaviour
{
    public Enemy[] enemyArr;
    public Turrets[] turrArr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chase PLayer");
            foreach (Enemy enemy in enemyArr)
            {
                enemy.chase = true;
            }

            foreach (Turrets tur in turrArr)
            {
                tur.chase = true;
            }
        }
    }
}