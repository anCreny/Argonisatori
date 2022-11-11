using JetBrains.Annotations;
using UnityEngine;

namespace ElectricNetwork
{
    public class Resistor : MonoBehaviour, IResistor, IElement
    {
        [SerializeField] private float resistance = 10;
        [SerializeField] private float _voltage;
        [SerializeField] private float _amperage;

        private bool _status;
        
        public float Amperage => _amperage;
        public float Resistance => resistance;
        public float Voltage => _voltage;

        [CanBeNull] private Signal _signal;

        [CanBeNull] private IElement _output;

        private bool _inNetwork;

        public bool InNetwork
        {
            set => _inNetwork = value;
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
            _signal = signal;
            React();
            SendSignal(signal);
        }

        public void TakeStatus(bool status)
        {
            _status = status;
            SendStatus(status);
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

        public void React()
        {
            if (!_signal.IsParallel)
            {
                if (!_signal.Calculated)
                {
                    _signal.AddResistance(this, resistance);
                }
                else
                {
                    if (_inNetwork)
                    {
                        _amperage = _signal.Amperage;
                        _voltage = _signal.Amperage * resistance;
                    }
                    else
                    {
                        _voltage = 0f;
                        _amperage = 0f;
                    }
                }
            }
            else
            {
                _signal.AddResistance(this, resistance);
            }
        }

        public void SetInNetwork(bool status)
        {
            _inNetwork = status;
        }

        private void Update()
        {
            if (_signal is not null && (_signal.EMF == 0f || !_status))
            {
                _voltage = 0f;
                _amperage = 0f;
            }
        }
    }
}