using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tracker : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _prefab;
    
    private Vector3 _mOffset;

    private float _mZCoord;

    private GameObject _tempCable;

    private void OnMouseDown()
    {
        _mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        _mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetMouseWorldPos()
    {
        var mousePoint = UnityEngine.Input.mousePosition;

        mousePoint.z = _mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
