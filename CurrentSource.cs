namespace XAKATON;

public class CurrentSource : Element
{
    private readonly Thread _electricChain;
    
    public CurrentSource(decimal innerResistance, decimal EMF, Condition condition)
    {
        Condition = condition;
        Condition.Status = false;

        _electricChain = new Thread(Work);
        Signal = GenerateSignal(EMF, innerResistance);
    }

    private Signal GenerateSignal(decimal EMF, decimal innerResistance)
    {
        return new Signal(EMF, innerResistance);
    }

    public void Start()
    {
        _electricChain.Start();
    }
    
    private void Work()
    {
        while (true)
        {
            SendStatus(true);
            SendCondition();
            while (Condition.Status)
            {
                SendSignal(Signal);
            }
            SendSignal(Signal.Interupted);
        }
    }   

    protected override void SendSignal(Signal signal)
    {
        Output?.TakeSignal(Signal);
    }

    public override void TakeSignal(Signal signal)
    {
        Signal = signal;
        Signal.Calculate();
    }

    public override void SetOutput(Element output)
    {
        Output = output;
    }

    public override void TakePreviousStatus(bool closed)
    {
        Condition.Status = closed;
    }

    public override void SendStatus(bool status)
    {
        Output?.TakePreviousStatus(status);
    }
}