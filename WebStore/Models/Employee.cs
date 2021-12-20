namespace WebStore.Model;

public class Employee
{
    public Employee()
    {
    }

    public Employee(int id, string firstName, string lastName, string patronymic, int age, int totalDaysInCompany)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Age = age;
        TotalDaysInCompany = totalDaysInCompany;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public int Age { get; set; }
    public int TotalDaysInCompany { get; set; }
}