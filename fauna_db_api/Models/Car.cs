namespace fauna_db_api.Models;

public class Car
{
    public string Id { get; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Kilometers { get; set; }

    public Car(string brand, string model, int year, int kilometers)
    {
        Id = Guid.NewGuid().ToString();
        Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Year = year;
        Kilometers = kilometers;
    }
}
