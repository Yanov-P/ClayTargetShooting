using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClayTargetShooting
{
    public class Player : MonoBehaviour
    {
        
        [SerializeField]
        private Transform _weaponPlace;

        private BaseWeapon _weaponInHand = null;
        private Interactable _interactable = null;


        void Update()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            if (Physics.Raycast(ray, out hit, 2.0f))
            {
                _interactable = hit.collider.GetComponent<Interactable>();
                _interactable?.OnFound();
            }
            else
            {
                _interactable = null;
            }  


        }

        public void Click() {
            if (_interactable != null)
            {
                if (_interactable is BaseWeapon)
                {
                    _interactable.Interact();
                    PickUpWeapon(_interactable as BaseWeapon);
                    _interactable = null;
                }
                else
                {
                    _interactable.Interact();
                }
            }
            else {
                if(_weaponInHand != null) _weaponInHand.Shoot();
            }
                
        }

        public void LeftSwipe()
        {
            _weaponInHand?.Reload();
        }

        private void PickUpWeapon(BaseWeapon weapon) {
            Debug.Log("Pick up " + weapon.gameObject.name);

            if (_weaponInHand != null) {
                _weaponInHand.gameObject.transform.position = weapon.gameObject.transform.position;
                _weaponInHand.gameObject.transform.rotation = weapon.gameObject.transform.rotation;
                _weaponInHand.gameObject.transform.parent = null;
                _weaponInHand.Placed();
            }

            weapon.gameObject.transform.position = _weaponPlace.position;
            weapon.gameObject.transform.rotation = _weaponPlace.rotation;
            weapon.gameObject.transform.parent = transform;
            _weaponInHand = weapon;

        }

        

    }
}