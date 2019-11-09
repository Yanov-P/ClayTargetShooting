using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClayTargetShooting
{
    public class ClayTarget : BaseTarget
    {
        [SerializeField]
        private GameObject _explodedTargetPrefab;
        private GameObject _explodedTarget;
        public UnityEvent _brokenEvent;
        public UnityEvent _brokenByPlayerEvent;
        private float _mass;

        void Start() {
            _mass = GetComponent<Rigidbody>().mass;
        }
        public override void Explode()
        {
            _brokenByPlayerEvent.Invoke();
            Break();
        }

        void OnDisable() {
            Destroy(_explodedTarget);
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.impulse.magnitude > 2 * _mass) {
                
                Break();
                _brokenEvent.Invoke();
            }
        }

        void OnEnable()
        {
            GetComponent<Collider>().enabled = true;
        }

        private void Break()
        {

            gameObject.SetActive(false);
            GetComponent<Collider>().enabled = false;
            if(_explodedTarget != null) Destroy(_explodedTarget);
            _explodedTarget = Instantiate(_explodedTargetPrefab, transform.position, transform.rotation);
            _explodedTarget.SetActive(true);
        }
    }
}