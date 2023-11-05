
using System;
using System.Threading;
using UnityEngine;
public class ChaseControl : MonoBehaviour
{
    public Enemy[] enemyArr;
    public Turrets[] turrArr;
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Chase player");
        if (other.gameObject.CompareTag("Player"))
        {
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