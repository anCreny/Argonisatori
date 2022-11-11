using System;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
namespace ElectricNetwork
{

    [Serializable]
    public class Signal
    {
        [SerializeField] private float _resistance;
        [SerializeField] private float _amperage;
        [SerializeField] private float _EMF;
        [SerializeField] private float _innerResistance;

        private bool _isParallel;

        public Signal ParallelSignal => new Signal(this);
        
        public bool IsParallel => _isParallel;

        private Signal _mainSignal;

        public Signal MainSignal => _mainSignal;

        private List<IResistor> _resistors;

        public Signal(float EMF, float innerResistance)
        {
            _resistors = new List<IResistor>();
            _EMF = EMF;
            _innerResistance = innerResistance;
            Calculated = false;
        }

        private Signal(Signal signal)
        {
            _mainSignal = signal;
            _isParallel = true;
            _resistors = new List<IResistor>();
            Calculated = false;
        }

        public List<IResistor> Resistors => new List<IResistor>(_resistors);

        public bool Calculated { get; private set; }

        public float Resistance => _resistance;

        public float Amperage => _amperage;

        public float EMF => _EMF;

        public float InnerResistance => _innerResistance;

        public static Signal Interupted => new Signal(0, 0);

        public Signal Zero => new Signal(_EMF, _innerResistance);

        public void AddResistance(IResistor resistor, float resistance)
        {
            if (_resistors.Contains(resistor)) return;
            _resistors.Add(resistor);
            _resistance += resistance;
        }

        public void Calculate()
        {
            _amperage = _EMF * 1.0f / (_resistance + _innerResistance) * 1.0f;
            Calculated = true;
        }
    }
}