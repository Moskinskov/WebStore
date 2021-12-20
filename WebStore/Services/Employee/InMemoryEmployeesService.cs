using WebStore.Data;

namespace WebStore.Services.Employee;

class InMemoryEmployeesService : IEmployeesService
{
    private readonly ILogger<InMemoryEmployeesService> logger;
    private readonly List<Model.Employee> employees;
    private int maxFreeId;


    public InMemoryEmployeesService(ILogger<InMemoryEmployeesService> logger)
    {
        this.logger = logger;
        employees = TestData.Employees.ToList();
        maxFreeId = employees.Count;
    }

    public IEnumerable<Model.Employee> GetAll()
    {
        return employees;
    }

    public Model.Employee? GetById(int id)
    {
        return employees.FirstOrDefault(employee => employee.Id == id);
    }

    public int Add(Model.Employee employee)
    {
        if (employee is null) throw new ArgumentNullException(nameof(employee));

        if (!employees.Contains(employee))
        {
            employee.Id = maxFreeId++;
            employees.Add(employee);
            logger.LogInformation($"Добавление сотрудника с ID {employee.Id}");
        }

        return employee.Id;
    }

    public bool Edit(Model.Employee employee)
    {
        if (employee is null) throw new ArgumentNullException(nameof(employee));

        if (employees.Contains(employee)) return true;

        Model.Employee? oldEmployee = GetById(employee.Id);
        if (oldEmployee is null) return false;
        else
        {
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.Patronymic = employee.Patronymic;
            oldEmployee.Age = employee.Age;
            oldEmployee.TotalDaysInCompany = employee.TotalDaysInCompany;
            return true;
        }
    }

    public bool Delete(int id)
    {
        Model.Employee? employee = GetById(id);
        if (employee is null)
        {
            logger.LogWarning($"Попытка удалить несуществующего сотрудника");
            return false;
        }

        employees.Remove(employee);
        logger.LogInformation($"Удаление сотрудника с ID {id}");
        return true;
    }
}