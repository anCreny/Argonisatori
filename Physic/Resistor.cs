using System.Text;

namespace XAKATON;

public class Resistor : Element, IResistor
{
    private decimal _resistance;

    private decimal _voltage;

    private decimal _amperage = decimal.Zero;

    public Resistor(decimal resistance)
    {
        _resistance = resistance;
    }

    protected override void SendSignal(Signal signal)
    {
        Output?.TakeSignal(signal);
    }

    public override void TakeSignal(Signal signal)
    {
        Signal = signal;
        React();
        SendSignal(Signal);
    }

    public override void SetOutput(Element output)
    {
        Output = output;
    }

    public override void TakePreviousStatus(bool closed)
    {
        SendStatus(closed);
    }

    public override void SendStatus(bool status)
    {
        Output?.TakePreviousStatus(status);
    }

    public decimal Amperage => _amperage;

    public decimal Resistance => _resistance;

    public decimal Voltage => _voltage;

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