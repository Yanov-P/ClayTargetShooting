using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneSearcher : MonoBehaviour
{
    private ARSessionOrigin _arOrigin;
    private ARRaycastManager _raycastManager;
    [SerializeField]
    private Material _planeMaterial;
    [SerializeField]
    private GameObject _defaultPlane;
    [SerializeField]
    private GameObject _gameInterior;
    void Awake()
    {
        _raycastManager = FindObjectOfType<ARRaycastManager>();
        _planeMaterial.color = new Color(0, 0, 0, 0.2f);

    }

    void Start() {
        _gameInterior.SetActive(false);

    }

    private void Update()
    {
        //Debug.Log("_raycastManager.subsystem.running " + _raycastManager.subsystem.running);

        UpdatePlacementPose();
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        if (_raycastManager.Raycast(screenCenter, hits, TrackableType.PlaneEstimated))
        {
            if (hits.Count > 0)
            {
                //Debug.Log("hits ocunt " + hits.Count);
                _gameInterior.transform.position = hits[0].pose.position;
                _gameInterior.transform.rotation = hits[0].pose.rotation;
                PlaceObject();
            }
        }
    }

    public void PlaceObject() {
        _gameInterior.SetActive(true);
        GetComponent<UIController>().PlaneFound();
        _defaultPlane.GetComponent<MeshRenderer>().enabled = false;
        _planeMaterial.color = new Color(0, 0, 0, 0);
        this.enabled = false;
    }
}
