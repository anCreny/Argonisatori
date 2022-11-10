namespace XAKATON;

public struct Signal
{
    private decimal _resistance;

    private decimal _amperage;

    private decimal _EMF;

    private decimal _innerResistance;

    private List<IResistor> _resistors = new List<IResistor>();
    
    public Signal(decimal EMF, decimal innerResistance)
    {
        _resistance = decimal.Zero;
        _amperage = decimal.Zero;
        _EMF = EMF;
        _innerResistance = innerResistance;
        Calculated = false;
    }

    public bool Calculated { get; private set; }

    public decimal Resistance => _resistance;

    public decimal Amperage => _amperage;

    public decimal EMF => _EMF;

    public decimal InnerResistance => _innerResistance;

    public static Signal Interupted => new Signal(decimal.Zero, decimal.Zero);

    public Signal Zero => new Signal(_EMF, _innerResistance);

    public void AddResistance(IResistor resistor, decimal resistance)
    {
        if (!_resistors.Contains(resistor))
        {
            _resistors.Add(resistor);
            _resistance += resistance;
        }
    }

    public void Calculate()
    {
        _amperage = _EMF / (_resistance + _innerResistance);
        Calculated = true;
    }
}