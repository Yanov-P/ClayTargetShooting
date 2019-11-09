using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainPanelInput : MonoBehaviour
    //, IEndDragHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    private Player _player;
    //private Vector2 _offset = new Vector2();
    //private Vector2 _startPos = new Vector2();
    //[SerializeField]
    //private const float MAX_CLICK_OFFSET = 8;
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    _offset = eventData.position;
    //}

    //public void OnDrag(PointerEventData eventData)
    //{

    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{

    //    _offset = eventData.position - _offset;
    //    //Debug.Log("OnEndDrag _offset " + _offset.magnitude);
    //    //if (_offset.x < -80) _player.ReloadWeapon();
    //    //if (_offset.x > 80) _player.RightSwipe();

    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    _startPos = eventData.position;
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    //if ((eventData.position - _startPos).magnitude < MAX_CLICK_OFFSET) {
    //    //    //Debug.Log("OnPointerUp " + (eventData.position - _startPos).magnitude);
    //    //    _player.Click();
    //    //}
    //}



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Click();
        }
    }
}
