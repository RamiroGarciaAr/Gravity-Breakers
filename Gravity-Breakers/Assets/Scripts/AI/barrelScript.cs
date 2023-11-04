using UnityEngine;

public class barrelScript : MonoBehaviour
{
        public void Awake()
        {
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
}