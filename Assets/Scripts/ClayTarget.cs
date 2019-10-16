using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClayTargetShooting
{
    public class ClayTarget : BaseTarget
    {
        [SerializeField]
        private GameObject _explodedTargetPrefab;
        public override void Explode()
        {
            var et = Instantiate(_explodedTargetPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}