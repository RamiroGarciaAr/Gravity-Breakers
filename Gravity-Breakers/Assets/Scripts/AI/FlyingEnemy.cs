
using UnityEngine;

public class FlyingEnemy : Enemy
{
        public float speed = 6f;
        public Vector3 delta;
        private GameObject player;
        private float threshold = 3f;
        public bool chase = false;

        public override void doDmg()
        {
                
        }
        
        public override void takeDmg()
        {
                
        }
        private void Start()
        {
                player = GameObject.FindGameObjectWithTag("Player");
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
                delta = new Vector3(player.transform.position.x - transform.position.x,
                        player.transform.position.y - transform.position.y,
                        player.transform.position.z - transform.position.z);
                this.transform.LookAt(new Vector3(player.transform.position.x,
                        player.transform.position.y,
                        player.transform.position.z));
                if (delta.magnitude > threshold)
                {
                        Vector3 velocity = delta.normalized * speed * Time.deltaTime;
                        this.transform.position = this.transform.position + velocity;
                }
        }
}
