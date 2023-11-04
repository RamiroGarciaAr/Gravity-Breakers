
using System;
using UnityEngine;
public class ChaseControl : MonoBehaviour
{
    public Enemy[] enemyArr;
    public Turrets[] turrArr;
    public GameObject player;

    /*private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player")
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Chase player");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chase PLayer numero 2");
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