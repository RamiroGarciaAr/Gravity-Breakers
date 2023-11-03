
using System;
using UnityEngine;

namespace Weapons
{
    public class Shooting : MonoBehaviour
    {
        private Vector3 _direction ;
        public float timeToDespawn = 10f;
        public float moveSpeed = 15f;
        public void Setup(Vector3 shootingDir)
        {
            this._direction = shootingDir;
            
        }

        public void Update()
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            Destroy(gameObject, timeToDespawn);
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy");
        }
    }
}