using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{
    float _timeStamp;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        _timeStamp = Time.time + 10;
    }

    void Update()
    {
        if (_timeStamp <= Time.time)
        {
            Destroy(gameObject);
        }
    }
}
