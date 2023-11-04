
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
        public EnemyStats stats;
        public bool chase = false;
        //[SerializeField] private float time = 5f;
        private float bulletTime;
        public float lambda = 2f;
        public bool attacked;
        public GameObject Bullet;
        private void Start()
        {
                stats.player = GameObject.FindGameObjectWithTag("Player");
                stats.speed = 7f;
                stats.threshold = 7f;
                stats.hp = 10;
                stats.dmg = 2;
        }

        private void Update()
        {
                if(chase) Invoke(nameof(shootAtPlayer),2f);
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
                this.transform.LookAt(new Vector3(playerPos.x,
                        playerPos.y,
                        playerPos.z));
                //Debug.Log(stats.delta);
                Vector3 velocity = stats.delta.normalized * (stats.speed * Time.deltaTime);

                if ((stats.delta.magnitude - lambda) > stats.threshold)
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
              transform.LookAt(stats.player.transform);

              

              if (!attacked)
              {
                      Rigidbody rb = Instantiate(Bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody>(); 
                      rb.AddForce(transform.forward * 32f,ForceMode.Impulse); 
                      
                      Destroy(rb.gameObject,stats.timeToDestoy);

                      attacked = true;
                      Invoke(nameof(ResetAttack),3f);
              }
        }

        private void ResetAttack()
        {
                attacked = false;
        }
}
