using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private GameObject[] _pooledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private int _amountToPool;
    private int _currentNum = 0;

    void Start()
    {
        _pooledObjects = new GameObject[_amountToPool];
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_objectToPool);
            obj.SetActive(false);
            _pooledObjects[i] = obj;
        }
    }

    public GameObject GetPooledObject()
    {
        if (_currentNum == _amountToPool) _currentNum = 0;
        Debug.Log("_currentNum = " + _currentNum);
        return _pooledObjects[_currentNum++];
    }
}
