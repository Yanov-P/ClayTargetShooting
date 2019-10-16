using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClayTargetShooting;

public class TestInteractable : Interactable
{
    public override void Interact()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("test interact");
    }

    

    public override void OnEndFoundAction()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public override void OnFoundAction()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
