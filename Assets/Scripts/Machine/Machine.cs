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
        private float _startRot;
        [SerializeField]
        private Transform _shitToRotate;
        [SerializeField]
        private float _rotationRange = 10;
        private Vector3 _rotStep = new Vector3(0, 0, 0.5f);
        private bool _increase = false;

        void Start() {
            var objectPooler = GetComponent<ObjectPooler>();
            objectPooler.AddListenersToTargets();
            _startRot = _shitToRotate.rotation.eulerAngles.z;
        }

        
        public void StartLaunch(float delayInSeconds) {
            Debug.Log("StartLaunch");
            GetComponent<Animator>().speed = 1 / delayInSeconds / 2;
            GetComponent<Animator>().SetTrigger("Launch");
            InvokeRepeating("Rotate", 0, 0.05f);
        }

        public void StopLaunch()
        {
            GetComponent<Animator>().SetTrigger("EndLaunch");
            GetComponent<MachineTargetsStorage>().Reset();
            CancelInvoke();
        }

        private void Rotate()
        {
            if (_shitToRotate.rotation.eulerAngles.z <= _startRot - _rotationRange)
            {
                _increase = true;
                //Debug.Log("_increase " + _increase);
            }
            else if (_shitToRotate.rotation.eulerAngles.z >=  _startRot + _rotationRange)
            {
                _increase = false;
                //Debug.Log("_increase " + _increase);
            }
            if (_increase)
            {
                _shitToRotate.Rotate(_rotStep);
                //Debug.Log("_increase " + _increase);
            }
            else
            {
                _shitToRotate.Rotate(-_rotStep);
                //Debug.Log("_increase " + _increase);
            }
            
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
