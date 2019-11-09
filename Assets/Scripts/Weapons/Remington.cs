using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClayTargetShooting
{
public class Remington : BaseWeapon
    {
        [SerializeField]
        GameObject _placeholder;
        [SerializeField]
        Transform _sleeveStart;
        [SerializeField]
        ParticleSystem _muzzleFlash;
        private int _bulletsInMagasine = 8;
        private int _maxBulletsInMagasine = 8;
        private Animator _animator;
        private int _layer_mask;
        private Outline _outline;
        public class ShootEvent : UnityEvent<int,int> { };
        public ShootEvent _shootEvent = new ShootEvent();
        public class ReloadEvent : UnityEvent<int, int> { };
        public ReloadEvent _reloadEvent = new ReloadEvent();

        void Awake() {
            _layer_mask = LayerMask.GetMask("Target");
            _animator = GetComponent<Animator>();
        }

        void Start() {

            _outline = gameObject.AddComponent<Outline>();
            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.yellow;
            _outline.OutlineWidth = 2f;
            _outline.enabled = false;
        }

        public override void Interact()
        {
            Debug.Log("Remington interact");
            //GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
        }

        public override void OnEndFoundAction()
        {
            _outline.enabled = false;
        }

        public override void OnFoundAction()
        {
            _outline.enabled = true;
        }

        public override void Placed()
        {
            //GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            _animator.SetTrigger("Placed");
        }

        public override void Reload()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("ReloadStart") || _animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
            {
                _animator.SetTrigger("EndReload");
                return;
            }
            if (_bulletsInMagasine < _maxBulletsInMagasine && (_animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot") || _animator.GetCurrentAnimatorStateInfo(0).IsName("IdleAnimation")))
            {
                _animator.SetTrigger("Reload");
            }
            
        }

        public void PickedUp() {
            _shootEvent.Invoke(_bulletsInMagasine, _maxBulletsInMagasine);
        }
        public void ShellEntered() {
            _bulletsInMagasine++;
            _reloadEvent.Invoke(_bulletsInMagasine, _maxBulletsInMagasine);
            if (_bulletsInMagasine >= _maxBulletsInMagasine) {
                _animator.SetTrigger("EndReload");
            }
        }

        public override void ShootAction()
        {
            //Debug.Log(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).shortNameHash);
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleAnimation"))
            {
                _bulletsInMagasine--;
                _shootEvent.Invoke(_bulletsInMagasine, _maxBulletsInMagasine);
                if (_bulletsInMagasine <= 0)
                {
                    Reload();
                }
                GetComponent<Animator>().SetTrigger("Shoot");
                _muzzleFlash.Play();
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

                if (Physics.SphereCast(ray, 0.3f, out hit, 200, _layer_mask))
                {
                    Debug.Log(hit.collider.name);
                    var target = hit.collider.GetComponent<BaseTarget>();
                    target?.Explode();
                }
                
            }
            //Instantiate(_sleevePrefab, _sleeveStart.position, _sleeveStart.rotation);
        }

        public void TurnLightOn() {
            GetComponent<Light>().enabled = true;
        }

        public void TurnLightOff()
        {
            GetComponent<Light>().enabled = false;
        }

        public void SpawnShell()
        {
            GameObject sleeve = GetComponent<ObjectPooler>().GetPooledObject();
            if (sleeve != null)
            {
                sleeve.GetComponent<Rigidbody>().isKinematic = true;
                sleeve.transform.position = _sleeveStart.transform.position;
                sleeve.transform.rotation = _sleeveStart.transform.rotation;
                sleeve.SetActive(true);
                sleeve.GetComponent<Rigidbody>().isKinematic = false;
                sleeve.GetComponent<Rigidbody>().AddForce(_sleeveStart.transform.forward * 10);
            }
        }

        
    }
}