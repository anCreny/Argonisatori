using ElectricNetwork;
using UnityEngine;

public class OutputElement : MonoBehaviour, IElement
{
    private IElement _output;
    
    public void TakeSignal(Signal signal)
    {
        SendSignal(signal);
    }

    private void SendSignal(Signal signal)
    {
        _output.TakeSignal(signal);
    }

    public void TakeStatus(bool status)
    {
        SendStatus(status);
    }

    private void SendStatus(bool status)
    {
        _output.TakeStatus(status);
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
