namespace fauna_db_api.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Kilometers { get; set; }

    public Car(int id, string brand, string model, int year, int kilometers)
    {
        Id = id;
        Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Year = year;
        Kilometers = kilometers;
    }
}
