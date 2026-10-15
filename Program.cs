public class ChargingStation
{
    public string Id { get; set; }
    public double MaxKw { get; set; }
    public bool IsAvailable { get; private set; } = true;

    public ChargingStation(string id, double maxKw)
    {
        if (maxKw <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxKw), "MaxKw måste vara större än 0.");
        }

        Id = id;
        MaxKw = maxKw;
    }
}