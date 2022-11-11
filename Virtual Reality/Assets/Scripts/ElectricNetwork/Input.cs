using ElectricNetwork;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class Input : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] [CanBeNull] private GameObject _sparksPrefab;

    private GameObject _sparks;
    
    [CanBeNull] private GameObject _output;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Output>().Cable is null)
        {
            if (_output is not null && _output != eventData.pointerDrag)
            {
                Interrupt();
            }

            _output = eventData.pointerDrag;
            eventData.pointerDrag.GetComponentInParent<IElement>().SetOutput(GetComponentInParent<IElement>());
            eventData.pointerDrag.GetComponent<Output>().Connect(gameObject);
            GetComponentInParent<IElement>().TakeStatus(false);
            _sparks.GetComponent<ParticleSystem>().Play();
        }
    }

    private void Interrupt()
    {
        if (_output is not null)
        {
            _output.GetComponentInParent<IElement>().Interrupt();
            _output.GetComponent<Output>().Interrupt();
        }
    }

    public void Clear()
    {
        _output = null;
        GetComponentInParent<IElement>().TakeStatus(false);
    }

    private void Start()
    {
        _sparks = Instantiate(_sparksPrefab, transform);
        _sparks.GetComponent<ParticleSystem>().Stop();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_output is not null)
        {
            eventData.pointerDrag = _output;
            eventData.pointerEnter = gameObject;
            GetComponentInParent<IElement>().TakeStatus(false);
            _output.GetComponent<Output>().Interrupt();
            _output.GetComponent<Output>().SetEndPosition(transform);
            _output.GetComponent<Output>().OnBeginDrag(eventData);
            _output = null;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
