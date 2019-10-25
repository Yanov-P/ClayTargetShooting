using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrame : MonoBehaviour
{

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        GetComponent<Animator>().SetTrigger("ZoomOut");
    }

    public void Deactivate() {
        gameObject.SetActive(false);
    }
}
