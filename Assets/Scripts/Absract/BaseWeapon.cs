
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClayTargetShooting
{
    public abstract class BaseWeapon : Interactable
    {
        
        [SerializeField]
        float _cooldownInSeconds;
        float _timeStamp = 0;

        public void Shoot()
        {
            if (_timeStamp <= Time.time) {
                ShootAction();
                _timeStamp = Time.time + _cooldownInSeconds;
            }
        }
        public abstract void ShootAction();
        public abstract void Placed();
        public abstract void Reload();
    }
}