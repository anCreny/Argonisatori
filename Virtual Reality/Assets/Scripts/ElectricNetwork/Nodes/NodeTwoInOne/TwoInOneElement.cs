using System.Collections;
using System.Collections.Generic;
using ElectricNetwork;
using UnityEngine;

public class TwoInOneElement : MonoBehaviour
{
    private Signal _firstParallelSignal;
    private Signal _secondParallelSignal;

    private bool _isFirstTHere;
    private bool _isSecondTHere;

    private Signal SetFirstSignal
    {
        set
        {
            _firstParallelSignal = value;
            _isFirstTHere = true;
        }
    }

    private Signal SetSecondSignal
    {
        set
        {
            _secondParallelSignal = value;
            _isSecondTHere = true;
        }
    }
    
    public void TakeFirstParallelSignal(Signal signal)
    {
        SetFirstSignal = signal;
        MergeParallelSignals();
    }

    public void TakeSecondParallelSignal(Signal signal)
    {
        SetSecondSignal = signal;
        MergeParallelSignals();
    }

    private void MergeParallelSignals()
    {
        if (_isFirstTHere && _isSecondTHere)
        {
            Signal CatchOriginalSignal(Signal signal)
            {
                if (signal.MainSignal.IsParallel)
                {
                    CatchOriginalSignal(signal.MainSignal);
                }

                return signal.MainSignal;
            }

            var originalSignal = CatchOriginalSignal(_firstParallelSignal);
            
            if (_firstParallelSignal.Resistors is null && _secondParallelSignal.Resistors is not null)
            {
                foreach (var resistor in _secondParallelSignal.Resistors)
                {
                    resistor.SetInNetwork(false);
                }
            }

            if (_secondParallelSignal.Resistors is null && _firstParallelSignal.Resistors is not null)
            {
                foreach (var resistor in _firstParallelSignal.Resistors)
                {
                    resistor.SetInNetwork(false);
                }
            }

            if (originalSignal.Calculated)
            {
                
            }
        }
    }
}
