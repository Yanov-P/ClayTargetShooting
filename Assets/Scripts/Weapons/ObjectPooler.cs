using ClayTargetShooting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private GameObject[] _pooledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    public int _amountToPool;
    [SerializeField]
    private GameManager _gameManager;
    private int _currentNum = 0;


    void Awake()
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
        //Debug.Log("get pooled " + (_currentNum + 1));
        return _pooledObjects[_currentNum++];
    }

    public int GetCurrentNum() {
        return _currentNum;
    }

    public void AddListenersToTargets(){
        foreach (var p in _pooledObjects) {
            p.GetComponent<ClayTarget>()._brokenEvent.AddListener(_gameManager.TargetBrokenHandler);
            p.GetComponent<ClayTarget>()._brokenByPlayerEvent.AddListener(_gameManager.TargetBrokenByPlayer);
        }
    }
}
