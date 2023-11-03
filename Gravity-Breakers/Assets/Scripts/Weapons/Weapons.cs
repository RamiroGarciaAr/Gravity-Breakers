using System;
using UnityEngine;

namespace Weapons
{
        public class Weapons: MonoBehaviour
        {
                public float timeBetweenShooting, timeBetweenShots, realoadTime, spread;
                
                public int magazine;

                private int _bulletsLeft, _bulletsShot;
    
                private bool _shooting, _realoading,_readyToShoot;

                public void Awake()
                {
                        _bulletsLeft = magazine;
                        _readyToShoot = true;
                }

                private void _shootingTime()
                {
                        if (!_realoading && _bulletsLeft > 0 && _readyToShoot && _shooting)
                        {
                                _bulletsShot = 0;
                                Shoot();
                        }       
                }

                private void Shoot()
                {
                        _readyToShoot = false;
                        _bulletsLeft--;
                        _bulletsShot++;
                }
        }
}