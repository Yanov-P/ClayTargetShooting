using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineTargetsStorage : MonoBehaviour
{
    private GameObject[] _storedTargets;
    [SerializeField]
    private GameObject _CTHelpers;
    [SerializeField]
    private GameObject _targetPrefab;
    [SerializeField]
    private int _targetsAmount = 60;
    private int _currNum;

    void Start() {
        _currNum = _targetsAmount + 2;
        _storedTargets = new GameObject[_targetsAmount + 3];
        for (int i = _storedTargets.Length - 1; i >= 0; i--)
        {
            _storedTargets[i] = Instantiate(_targetPrefab);
            //Debug.Log("i " + i);
            Transform currChild = _CTHelpers.transform.GetChild(_CTHelpers.transform.childCount - (i % _CTHelpers.transform.childCount) - 1);
            _storedTargets[i].transform.position = currChild.position + currChild.forward * (i / _CTHelpers.transform.childCount) * 0.03f;
            //+ new Vector3(0,i/_CTHelpers.transform.childCount * 0.03f, 0)
            _storedTargets[i].transform.rotation = currChild.rotation;
            _storedTargets[i].transform.parent = currChild;
            _storedTargets[i].SetActive(true);
        }
    }

    public void Next() {
        _storedTargets[_currNum].SetActive(false);
        _currNum--;
        if (_currNum < 0) {
            Reset();
        }
    }

    public void Reset() {
        foreach (var a in _storedTargets)
        {
            a.SetActive(true);
        }
        _currNum = _targetsAmount + 2;
    }
}
