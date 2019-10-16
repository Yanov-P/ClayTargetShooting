using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : BaseWeapon
{
    [SerializeField]
    GameObject _bulletPrefab;
    [SerializeField]
    Transform _bulletStart;

    public override void Interact()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
    }

    public override void OnEndFoundAction()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public override void OnFoundAction()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public override void Placed()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
    }

    public override void Reload()
    {
        
    }

    public override void ShootAction()
    {
        Instantiate(_bulletPrefab, _bulletStart.position, _bulletStart.rotation);
    }
}
