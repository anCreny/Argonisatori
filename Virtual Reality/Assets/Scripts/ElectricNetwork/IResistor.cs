namespace ElectricNetwork
{
    public interface IResistor
    {
        public void React();

        public void SetInNetwork(bool status);
    }
}