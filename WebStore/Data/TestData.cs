using WebStore.Model;

namespace WebStore.Data;

public class TestData
{
    private static readonly Employee[] employees = new[]
    {
        new Employee(id: 0, firstName: "Илья", lastName: "Иванов", patronymic: "Иванович", age: 13,
            totalDaysInCompany: 90),
        new Employee(id: 1, firstName: "Максим", lastName: "Иванов", patronymic: "Ильич", age: 31,
            totalDaysInCompany: 190),
        new Employee(id: 2, firstName: "Софья", lastName: "Ива", patronymic: "Максимовна", age: 14,
            totalDaysInCompany: 10),
        new Employee(id: 3, firstName: "Илья", lastName: "Ивановов", patronymic: "Иванович", age: 32,
            totalDaysInCompany: 230),
    };

    public static Employee[] Employees => employees;
}