
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
        public float speed = 10f;
        public GameObject player;
        public bool chase = false;
        public Transform startPoint;

        private void Start()
        {     
                player = GameObject.FindGameObjectWithTag("Player");
        }


        void Update()
        {

                if (chase == true)
                {
                        Chase();
                }
        }

        private void Chase()
        {
                Debug.Log("chase");
                transform.position = 
                        Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
}
