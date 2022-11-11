using ElectricNetwork;
using JetBrains.Annotations;
using UnityEngine;

public class Output1 : MonoBehaviour, IElement
{
    [CanBeNull] private IElement _output; 
    
    private void SendSignal(Signal signal)
    {
        if (_output is not null)
        {
            _output.TakeSignal(signal);
        }
    }
    
    public void TakeSignal(Signal signal)
    {
        SendSignal(signal);
    }

    public void TakeStatus(bool status)
    {
        SendStatus(status);
    }

    private void SendStatus(bool status)
    {
        if (_output is not null)
        {
            _output.TakeStatus(status);
        }
    }

    public void SetOutput(IElement output)
    {
        _output = output;
    }

    public void Interrupt()
    {
        _output = null;
    }
}
