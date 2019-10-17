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
        private GameObject _CTHelpers;
        private Transform _targetStart;

        void Start() {
            var objectPooler = GetComponent<ObjectPooler>();
            for (int i = 0; i < _CTHelpers.transform.childCount; i++) {
                GameObject target = objectPooler.GetPooledObject();
                target.transform.position = _CTHelpers.transform.GetChild(i).position;
                target.transform.rotation = _CTHelpers.transform.GetChild(i).rotation;
                target.SetActive(true);
            }
        }
        public void StartLaunch(int delayInSeconds) {
            InvokeRepeating("LaunchTarget", 3, delayInSeconds);
        }

        public void StopLaunch()
        {
            CancelInvoke();
        }

        private void LaunchTarget() {
            GameObject target = GetComponent<ObjectPooler>().GetPooledObject();
            if (target != null)
            {
                target.GetComponent<Rigidbody>().isKinematic = true;
                target.transform.position = _targetStart.transform.position;
                target.transform.rotation = _targetStart.transform.rotation;
                target.SetActive(true);
                target.GetComponent<Rigidbody>().isKinematic = false;
                target.GetComponent<Rigidbody>().AddForce(_targetStart.transform.forward * 10);
            }
        }
    }
}
