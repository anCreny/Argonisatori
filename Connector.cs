namespace XAKATON;

public class Connector
{
    public void Connect(Element input, Element output)
    {
        input.SetOutput(output);
    }

    public void Disconnect(Element target)
    {
        target.Output?.TakePreviousStatus(false);
    }
}