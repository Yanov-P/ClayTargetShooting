using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _timeStamp;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 100);
        _timeStamp = Time.time + 10;
    }

    void Update() {
        if (_timeStamp <= Time.time) {
            Destroy(gameObject);
        }
    }

    
}
