using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClayTargetShooting
{
    public class ClayTarget : BaseTarget
    {
        [SerializeField]
        private GameObject _explodedTargetPrefab;
        private GameObject _explodedTarget;
        public delegate void ClayTargetBroken(bool byPlayer);
        public static event ClayTargetBroken OnTargetBroken;

    public override void Explode()
        {
            var _explodedTarget = Instantiate(_explodedTargetPrefab, transform.position, transform.rotation);
            OnTargetBroken(true);
            Invoke("DestroyExploded", 3);
            gameObject.SetActive(false);
        }

        private void DestroyExploded() {
            Destroy(_explodedTarget);
        }
    }
}