
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
        public EnemyStats stats;
        public bool chase = false;
        [SerializeField] private float time = 5f;
        private float bulletTime;
        public GameObject enemyBullet;
        public Transform spawnPoint;
        private void Start()
        {
                stats.player = GameObject.FindGameObjectWithTag("Player");
                stats.speed = 7f;
                stats.threshold = 5f;
                stats.hp = 10;
                stats.dmg = 2;
        }


        void Update()
        {

                if (chase)
                {
                        Chase();
                        shootAtPlayer();
                       
                }
        }
        
        
               
        private void Chase() 
        {
                var playerPos = stats.player.transform.position;
                var position1 = transform.position;
                stats.delta = new Vector3(playerPos.x - position1.x,
                        playerPos.y - position1.y,
                        playerPos.z - position1.z);
                this.transform.LookAt(new Vector3(playerPos.x,
                        playerPos.y,
                        playerPos.z));
                //Debug.Log(stats.delta);
                if (stats.delta.magnitude > stats.threshold)
                {
                        Vector3 velocity = stats.delta.normalized * (stats.speed * Time.deltaTime);
                        this.transform.position += velocity;
                        //Debug.Log(velocity);
                }
        }

        private void shootAtPlayer()
        {
                //Debug.Log("shooting");
                bulletTime -= Time.deltaTime;

                if (bulletTime > 0) return;

                bulletTime = time;

                GameObject bulletObj = Instantiate(enemyBullet,spawnPoint.transform.position,spawnPoint.transform.rotation) ;
                var playerPos = stats.player.transform.position;
                Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
                bulletRig.AddForce(new Vector3(playerPos.x, playerPos.y, playerPos.z).normalized * stats.speed);
                //Destroy(bulletObj,5f);
        }
}
