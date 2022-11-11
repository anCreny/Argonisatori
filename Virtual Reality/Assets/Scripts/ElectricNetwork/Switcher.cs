using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

namespace ElectricNetwork
{
    public class Switcher : MonoBehaviour, IElement
    {
        [SerializeField] private bool _isSwitchedOn;
        [CanBeNull] private IElement _output;
        private bool _status;

        public bool Status
        {
            get => _isSwitchedOn;
            set => _isSwitchedOn = value;
        }
    
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
            SendStatus(_isSwitchedOn && status);
        }

        public void SetOutput(IElement output)
        {
            _output = output;
        }

        public void Interrupt()
        {
            _output = null;
        }

        private void SendStatus(bool status)
        {
            if (_output is not null)
            {
                _output.TakeStatus(status);
            }
        }
    }
}