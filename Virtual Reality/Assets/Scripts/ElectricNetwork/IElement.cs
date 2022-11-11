using System;
using System.Runtime.Serialization;
using Unity.VisualScripting;

namespace ElectricNetwork
{
    public interface IElement
    {
        public void TakeSignal(Signal signal);

        public void TakeStatus(bool status);

        public void SetOutput(IElement output);

        public void Interrupt();
    }
}