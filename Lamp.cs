namespace XAKATON;

public class Lamp: Element, IResistor
{

    private decimal _resistance;
    private decimal _voltage;
    private decimal _amperage;
    private bool _isLampOn;

    public Lamp(decimal resistance)
    {
        _isLampOn = false;
        _resistance = resistance;
    }
    
    protected override void SendSignal(Signal signal)
    {
        Output?.TakeSignal(signal);
    }

    public override void TakeSignal(Signal signal)
    {
        if (!(signal.Amperage == 0 && signal.Resistance == 0))
        {
            _isLampOn = true;
        }
        else
        {
            _isLampOn = false;
        }
        React();
        SendSignal(signal);
    }

    public override void SetOutput(Element output)
    {
        Output = output;
    }

    public override void TakePreviousStatus(bool closed)
    {
        Condition.Status = closed;
        _isLampOn = closed;
        SendStatus(closed);
    }

    public override void SendStatus(bool status)
    {
        Output?.TakePreviousStatus(status);
    }

    public void React()
    {
        if (!Signal.Calculated)
        {
            Signal.AddResistance(this, _resistance);
        }
        else
        {
            _amperage = Signal.Amperage;
            _voltage = Signal.Amperage * _resistance;
        }
    }
}