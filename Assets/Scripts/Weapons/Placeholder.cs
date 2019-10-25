using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : BaseWeapon
{
    private Outline _outline;
    void Start() {
        _outline = gameObject.AddComponent<Outline>();

        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = Color.yellow;
        _outline.OutlineWidth = 2f;
        _outline.enabled = false;
    }
    public override void Interact()
    {
        GetComponent<Collider>().enabled = false;
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
        GetComponent<Collider>().enabled = true;
    }

    public override void Reload()
    {
    }

    public override void ShootAction()
    {
    }

}
