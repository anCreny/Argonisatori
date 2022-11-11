using ElectricNetwork;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class Output : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private float _mZCoord;

    private GameObject _tempCable;

    [CanBeNull] private Transform _newEnd;
    
    [SerializeField] [CanBeNull] private GameObject _prefab;

    [CanBeNull] private GameObject _cable;

    [CanBeNull] public GameObject Cable => _cable;
    private Vector3 GetMouseWorldPos()
    {
        var mousePoint = UnityEngine.Input.mousePosition;

        mousePoint.z = _mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    private Vector3 EndNode
    {
        get => _cable.GetComponentsInChildren<Transform>()[2].position;
        set => _cable.GetComponentsInChildren<Transform>()[2].position = value;
    }

    private Vector3 EndPoint
    {
        get => _input.transform.position;
    }

    public void SetEndPosition(Transform endTransform)
    {
        _newEnd = endTransform;
    }

    [CanBeNull] private GameObject _input;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_cable is null)
        {
            Debug.Log("OnBeginDrag");

            _tempCable = Instantiate(_prefab);

            _tempCable.GetComponentsInChildren<Transform>()[1].transform.position = transform.position;
            var position = _newEnd is not null ? _newEnd.position : gameObject.transform.position;
            if (Camera.main != null) _mZCoord = Camera.main.WorldToScreenPoint(position).z;
            
            _tempCable.GetComponentsInChildren<Transform>()[2].position = GetMouseWorldPos();
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(_tempCable);
        _tempCable = null;
        _mZCoord = 0f;
        _newEnd = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_cable is null)
        {
            _tempCable.GetComponentsInChildren<Transform>()[2].position = GetMouseWorldPos();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDROP");
    }

    private void Update()
    {
        if (_cable is not null && _input is not null && EndNode != EndPoint)
        {
            EndNode = EndPoint;
        }
    }

    public void Connect(GameObject endPoint)
    {
        if (_cable is null)
        {
            _cable = Instantiate(_prefab);
            if (_cable is not null)
            {
                _cable.GetComponentsInChildren<Transform>()[1].position = transform.position;
            }
        }

        if (_input is not null)
        {
            _input.GetComponent<Input>().Clear();
        }
        _input = endPoint;
    }

    public void Interrupt()
    {
        Destroy(_cable);
        GetComponentInParent<IElement>().Interrupt();
        _cable = null;
        _input = null;
    }
}
