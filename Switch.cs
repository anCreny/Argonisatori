namespace XAKATON;

public class Switch : Element
{
    private bool _isSwitchedOn; 
    
    protected override void SendSignal(Signal signal)
    {
        Output?.TakeSignal(signal);
    }

    public override void TakeSignal(Signal signal)
    {
        SendSignal(_isSwitchedOn ? signal : signal.Zero);
    }

    public void SwitchOff()
    {
        _isSwitchedOn = false;
    }
    public void SwitchOn()
    {
        _isSwitchedOn = true;
    }
    public override void SetOutput(Element output)
    {
        Output = output;
    }

    public override void TakePreviousStatus(bool closed)
    {
        SendStatus(_isSwitchedOn && closed);
    }

    public override void SendStatus(bool status)
    {
        Condition.Status = status;
        Output?.TakePreviousStatus(status);
    }
}