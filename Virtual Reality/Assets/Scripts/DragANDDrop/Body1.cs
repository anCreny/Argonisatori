using DragANDDrop;
using JetBrains.Annotations;
using UnityEngine;

public class Body1 : MonoBehaviour, El
{ 
    [SerializeReference] [CanBeNull] private El _output;
    
    private bool _isConnected;

    public bool IsConnected
    {
        get => _isConnected;
        set => _isConnected = value;
    }

    public void Interrupt()
    {
        _output = null;
    }

    private Color Color
    {
        get => GetComponent<Renderer>().material.color;
        set => GetComponent<Renderer>().material.color = value;
    }
    void Start()
    {
        Color = Random.ColorHSV();
    }

    void FixedUpdate()
    {
        if (_output is not null)
        {
            SendColor(Color);
        }
    }

    private void OnMouseUp()
    {
        Color = Random.ColorHSV();
    }

    public void SetOutput(El element)
    {
        if (_output is not null)
        {
            _output.Interrupt();
        }

        _output = element;
    }

    private void SendColor(Color color)
    {
        if (_output is not null)
        {
            _output.TakeColor(color);
        }
    }

    public void TakeColor(Color color)
    {
        Color = color;
        SendColor(color);
    }
}
