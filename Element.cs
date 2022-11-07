namespace XAKATON;

public abstract class Element
{
    protected Signal Signal;

    protected Condition Condition;

    public Element? Output { get; protected set; }

    protected abstract void SendSignal(Signal signal);

    public abstract void TakeSignal(Signal signal);

    public abstract void SetOutput(Element output);

    public abstract void TakePreviousStatus(bool closed);

    public abstract void SendStatus(bool status);

    protected void SendCondition()
    {
        Output?.TakeCondition(this.Condition);
    }

    private void TakeCondition(Condition condition)
    {
        this.SendCondition();
    }
}