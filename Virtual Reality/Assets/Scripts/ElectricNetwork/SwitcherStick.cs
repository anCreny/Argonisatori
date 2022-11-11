using ElectricNetwork;
using UnityEngine;

public class SwitcherStick : MonoBehaviour
{
    private bool _status
    {
        get => GetComponentInParent<Switcher>().Status;
        set => GetComponentInParent<Switcher>().Status = value;
    }
    
    private void OnMouseUp()
    {
        _status = !_status;
        GetComponentInChildren<SwitchON>().TakeStatus(_status);
        GetComponentInChildren<SwitchOFF>().TakeStatus(_status);
    }

    private void Awake()
    {
        GetComponentInChildren<SwitchON>().TakeStatus(_status);
        GetComponentInChildren<SwitchOFF>().TakeStatus(_status);
    }
}
