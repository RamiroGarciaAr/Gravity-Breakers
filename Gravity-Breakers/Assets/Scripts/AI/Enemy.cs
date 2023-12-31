
using UnityEngine;

public class Enemy : MonoBehaviour
{
        public EnemyStats stats;
        public bool chase;
        private float bulletTime;
        public bool attacked;
        public GameObject Bullet;
        public float bulletSpeed = 22f;
        public Transform gunBarrel;
        public float rotSpeed = 3f;

        public EnemyHealth enemyHP;
        
        
        public float amplitud = 2;
        public float speed = 1.5f;
        
        public KeyCode dmg = KeyCode.K;
        private void Start()
        {
                stats.player = GameObject.FindGameObjectWithTag("Player");
                
        }

        private void Update()
        {
                if (chase)
                {
                        Debug.Log("Chase");
                        Invoke(nameof(shootAtPlayer),2f);
                }
                if(Input.GetKeyDown(dmg))
                {
                        enemyHP.getHit(100f);
                }
        }

        void LateUpdate()
        {

                if (chase)
                {
                        Chase();
                       
                }
        }
        
        
               
        private void Chase() 
        {
                var playerPos = stats.player.transform.position;
                var position1 = transform.position;
                stats.delta = new Vector3(playerPos.x - position1.x,
                        playerPos.y - position1.y,
                        playerPos.z - position1.z);
                
                Vector3 dir = transform.position - stats.player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(-dir);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
                
                //Debug.Log(stats.delta);
                Vector3 velocity = stats.delta.normalized * (stats.speed * Time.deltaTime);

                if ((stats.delta.magnitude - stats.lambda) > stats.threshold)
                {
                        this.transform.position += velocity;
                        //Debug.Log(velocity);
                }
                else if(stats.delta.magnitude < stats.threshold)
                {
                        this.transform.position -= velocity;
                }
        }

        private void shootAtPlayer()
        {

              if (!attacked)
              {
                      Rigidbody rb = Instantiate(Bullet,gunBarrel.transform.position,Quaternion.identity).GetComponent<Rigidbody>(); 
                      rb.AddForce(transform.forward * bulletSpeed,ForceMode.Impulse); 
                      
                      Destroy(rb.gameObject,stats.timeToDestoy);

                      attacked = true;
                      Invoke(nameof(ResetAttack),3f);
              }
        }
        
        public void ResetAttack()
        {
                attacked = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Bullet"))
                {
                        Destroy(other.gameObject);
                        enemyHP.getHit(25f);
                }
        }
        
}
