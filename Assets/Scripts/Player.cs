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
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private BaseWeapon _testWeaponInHand;
        [SerializeField]
        private BaseWeapon _weaponInHand;
        private Interactable _interactable;

        void Start() {
            if (_testWeaponInHand is BaseWeapon) {
                _testWeaponInHand.Interact();
                PickUpWeapon(_testWeaponInHand);
                PickUpWeapon(_testWeaponInHand);
            }
        }
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
            Debug.Log("Click");
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

        public void ReloadWeapon()
        {
            if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "AimAnimation") {
                GetComponent<Animator>().SetTrigger("Aim");
            }
            _weaponInHand?.Reload();
            //_gameManager.StartGame();
        }

        private void PickUpWeapon(BaseWeapon weapon) {
            Debug.Log("Pick up " + weapon.gameObject.name);
            Debug.Log("M2");
            if (weapon is Placeholder)
            {
                _gameManager.FinishGame();
                Debug.Log("M4");
            }
            else
            {
                _gameManager.StartGame();
                Debug.Log("M5");
            }

            Debug.Log("M1");
            
            if (_weaponInHand != null) {
                _weaponInHand.gameObject.transform.position = weapon.gameObject.transform.position;
                _weaponInHand.gameObject.transform.rotation = weapon.gameObject.transform.rotation;
                _weaponInHand.gameObject.transform.parent = null;
                _weaponInHand.Placed();
                if (_weaponInHand is Remington) {
                    (_weaponInHand as Remington)._shootEvent.RemoveAllListeners();
                }
            }
            Debug.Log("M3");
            Debug.Log("position " + weapon.transform.position);
            weapon.gameObject.transform.position = _weaponPlace.position;
            weapon.gameObject.transform.rotation = _weaponPlace.rotation;
            weapon.gameObject.transform.parent = _weaponPlace;
            _weaponInHand = weapon;
            Debug.Log("position " + weapon.transform.position);
            if (_weaponInHand is Remington)
            {
                (_weaponInHand as Remington)._shootEvent.AddListener(_gameManager.PlayerAmmoHandler);
                (_weaponInHand as Remington)._reloadEvent.AddListener(_gameManager.PlayerReloadHandler);
                (_weaponInHand as Remington).PickedUp();
            }

        }

        public void Aim() {
            Debug.Log("Aim");
            GetComponent<Animator>().SetTrigger("Aim");
        }

    }
}