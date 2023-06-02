namespace fauna_db_api.Models;

public class User
{
    public string Id { get; set; }
    public Car Car { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }



    public User(string id, Car car, string firstName, string lastName, string email)
    {
        Id = id;
        Car = car ?? throw new ArgumentNullException(nameof(car));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}
