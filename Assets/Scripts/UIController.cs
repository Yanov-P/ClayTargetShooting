using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _planeSearchPanel;
    [SerializeField]
    private GameObject _testPanel;
    void Start()
    {
        _mainPanel.SetActive(false);
        _planeSearchPanel.SetActive(true);
        if (Application.platform == RuntimePlatform.WindowsEditor) _testPanel.SetActive(true);
        else _testPanel.SetActive(false);
    }

    public void PlaneFound() {
        _mainPanel.SetActive(true);
        _planeSearchPanel.SetActive(false);
        
    }

}
