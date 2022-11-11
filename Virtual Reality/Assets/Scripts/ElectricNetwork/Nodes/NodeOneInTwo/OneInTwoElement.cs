using ElectricNetwork;
using UnityEngine;

public class OneInTwoElement : MonoBehaviour, IElement
{
    public void TakeSignal(Signal signal)
    {
        SendParallelSignals(signal);
    }

    private void SendParallelSignals(Signal signal)
    {
        GetComponentInParent<Output1>().TakeSignal(signal.ParallelSignal);
        GetComponentInParent<Output2>().TakeSignal(signal.ParallelSignal);
    }

    public void TakeStatus(bool status)
    {
        SendStatus(status);
    }

    public void SetOutput(IElement output)
    {
    }

    private void SendStatus(bool status)
    {
        GetComponentInParent<Output1>().TakeStatus(status);
        GetComponentInParent<Output2>().TakeStatus(status);
    }

    public void Interrupt()
    {
    }
}
