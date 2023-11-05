using UnityEngine;


public class checkPoint : MonoBehaviour 
{
        public RespawnScreen reviveState;

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                reviveState.lastTriggerPosition = gameObject.transform.position;
            }
        }
}