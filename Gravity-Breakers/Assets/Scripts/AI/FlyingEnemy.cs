
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
        public EnemyStats stats;
        public bool chase = false;
        private void Start()
        {
                stats.player = GameObject.FindGameObjectWithTag("Player");
                stats.speed = 6f;
                stats.threshold = 3f;
                stats.hp = 10;
                stats.dmg = 2;
        }

        
        void LateUpdate()
        {

                if (chase == true)
                {
                        Chase();
                }
        }
        
        
               
        private void Chase() 
        {
                stats.delta = new Vector3(stats.player.transform.position.x - transform.position.x,
                        stats.player.transform.position.y - transform.position.y,
                        stats.player.transform.position.z - transform.position.z);
                this.transform.LookAt(new Vector3(stats.player.transform.position.x,
                        stats.player.transform.position.y,
                        stats.player.transform.position.z));
                if (stats.delta.magnitude > stats.threshold)
                {
                        Vector3 velocity = stats.delta.normalized * stats.speed * Time.deltaTime;
                        this.transform.position = this.transform.position + velocity;
                }
        }
}
