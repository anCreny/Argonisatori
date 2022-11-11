using System.Collections;
using System.Collections.Generic;
using ElectricNetwork;
using UnityEngine;

public class Input1 : MonoBehaviour, IElement
{
    public void TakeSignal(Signal signal)
    {
        throw new System.NotImplementedException();
    }

    public void TakeStatus(bool status)
    {
        throw new System.NotImplementedException();
    }

    public void SetOutput(IElement output)
    {
        throw new System.NotImplementedException();
    }

    public void Interrupt()
    {
        throw new System.NotImplementedException();
    }
}
