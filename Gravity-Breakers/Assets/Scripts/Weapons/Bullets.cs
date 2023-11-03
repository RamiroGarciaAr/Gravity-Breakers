using UnityEngine;

namespace Weapons
{
    public class Bullets : MonoBehaviour
    {
        //Bullet
        public GameObject bullet;
    
        //Force
        public float shootingForce, upwardsForce;
        
    
        //Camera
        public Camera fpsCam;
        public Transform attackPoint;
    }
}
