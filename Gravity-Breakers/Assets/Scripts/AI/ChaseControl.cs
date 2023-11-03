using System;
using UnityEngine;
public class ChaseControl : MonoBehaviour
{
    public FlyingEnemy[] enemyArr;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chase PLayer");
            foreach (FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = true;
            }
        }
    }
}