using System;
using JetBrains.Annotations;
using UnityEngine;

namespace ElectricNetwork
{
    [Serializable]
    public class CurrentSoruce : MonoBehaviour, IElement
    {
        [CanBeNull] private IElement _output;
        [SerializeField] private float _EMF = 100;
        [SerializeField] private float _innerResistance = 5;

        [SerializeField] private bool _status;
        [SerializeField] private Signal _signal;

        public float EMF => _EMF;
        public float InnerResistance => _innerResistance;
        public Signal Signal => _signal;
        
        private Signal GenerateSignal(float EMF, float innerResistance)
        {
            return new Signal(EMF, innerResistance);
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
            if (signal.EMF != 0)
            {
                _signal = signal;
                _signal.Calculate();
            }
        }

        public void TakeStatus(bool status)
        {
            if (_status == status) return;
            _signal = GenerateSignal(_EMF, _innerResistance);
            _status = status;
        }

        public void SetOutput(IElement output)
        {
            _output = output;
        }

        public void Interrupt()
        {
            _output = null;
            TakeStatus(false);
        }

        private void SendStatus(bool status)
        {
            if (_output is not null)
            {
                _output.TakeStatus(status);
            }
        }

        void Start()
        {
            _signal = GenerateSignal(_EMF, _innerResistance);
        }

        void FixedUpdate()
        {
            SendStatus(true);
            if (_status)
            {
                SendSignal(_signal);
            }
            else
            {
                SendSignal(Signal.Interupted);
            }
        }
        
    }

}