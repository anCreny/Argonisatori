namespace XAKATON;

public class Wire : Element
{
    //vector3
    private readonly int _startPoint;
    //vector3
    private readonly int _endPoint;

    public Wire(int startPoint, int endPoint)
    {
        _endPoint = endPoint;
        _startPoint = startPoint; 
    }

    protected override void SendSignal(Signal signal)
    {
        if (Condition.Status)
        {
            Output?.TakeSignal(signal);
        }
    }

    public override void TakeSignal(Signal signal)
    {
        Signal = signal;
        SendSignal(Signal);
    }

    public override void SetOutput(Element output)
    {
        Output = output;
    }

    public override void TakePreviousStatus(bool status)
    {
        SendStatus(status);
    }

    public override void SendStatus(bool status)
    {
        Output?.TakePreviousStatus(status);
    }
}