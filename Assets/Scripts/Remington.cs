using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClayTargetShooting
{
public class Remington : BaseWeapon
    {
        [SerializeField]
        GameObject _sleevePrefab;
        [SerializeField]
        Transform _sleeveStart;

        public override void Interact()
        {
            Debug.Log("Remington interact");
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }

        public override void OnEndFoundAction()
        {
            
        }

        public override void OnFoundAction()
        {
            
        }

        public override void Placed()
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
        }

        public override void Reload()
        {
            Debug.Log("Reload");
        }

        public override void ShootAction()
        {
            GameObject sleeve = GetComponent<ObjectPooler>().GetPooledObject();
            if (sleeve != null) {
                sleeve.GetComponent<Rigidbody>().isKinematic = true;
                sleeve.transform.position = _sleeveStart.transform.position;
                sleeve.transform.rotation = _sleeveStart.transform.rotation;
                sleeve.SetActive(true);
                sleeve.GetComponent<Rigidbody>().isKinematic = false;
                sleeve.GetComponent<Rigidbody>().AddForce(_sleeveStart.transform.forward * 10);
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                Debug.Log(hit.collider.name);
                var target = hit.collider.GetComponent<BaseTarget>();
                target?.Explode();
            }
            //Instantiate(_sleevePrefab, _sleeveStart.position, _sleeveStart.rotation);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}