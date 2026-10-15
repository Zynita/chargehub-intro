using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ChargingStation station = new ChargingStation("AC-01", 11);

            station.StartCharging();
            Console.WriteLine("Första laddningen har startats.");

            station.StartCharging();
            Console.WriteLine("Andra laddningen har startats.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Felmeddelande: {ex.Message}");
        }
    }
}

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

    public void StartCharging()
    {
        if (!IsAvailable)
        {
            throw new InvalidOperationException($"{Id} är upptagen.");
        }
        IsAvailable = false;
    }

    public void StopCharging()
    {
        IsAvailable = true;
    }
}