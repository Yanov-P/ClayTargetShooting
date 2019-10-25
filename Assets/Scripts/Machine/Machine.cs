using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClayTargetShooting
{
    class Machine : MonoBehaviour
    {
        
        [SerializeField]
        private Transform _targetStart;
        private GameObject _target;
        

        void Start() {
            var objectPooler = GetComponent<ObjectPooler>();
            objectPooler.AddListenersToTargets();
        }

        
        public void StartLaunch(float delayInSeconds) {
            GetComponent<Animator>().speed = 1 / delayInSeconds / 2;
            GetComponent<Animator>().SetTrigger("Launch");
        }

        public void StopLaunch()
        {
            GetComponent<Animator>().SetTrigger("EndLaunch");
            GetComponent<MachineTargetsStorage>().Reset();
        }
        public void PickTarget()
        {
            var objectPooler = GetComponent<ObjectPooler>();
            //Debug.Log("PickTarget objectPooler.GetCurrentNum()" + objectPooler.GetCurrentNum());
            
            _target = objectPooler.GetPooledObject();

            GetComponent<MachineTargetsStorage>().Next();

            if (_target != null)
            {
                _target.SetActive(false);
                _target.GetComponent<Rigidbody>().isKinematic = true;
                _target.transform.position = _targetStart.transform.position;
                _target.transform.rotation = _targetStart.transform.rotation;
                _target.transform.parent = _targetStart.transform;
                _target.SetActive(true);
                
            }
            
        }

        public void LaunchTarget() {
            if (_target != null)
            {
                _target.transform.parent = null;
                _target.GetComponent<Rigidbody>().isKinematic = false;
                _target.GetComponent<Rigidbody>().AddForce( - _targetStart.transform.right * 5 + _targetStart.transform.forward * 2);

            }
            
        }

        
    }
}
