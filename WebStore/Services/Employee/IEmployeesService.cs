namespace WebStore.Services.Employee;

public interface IEmployeesService
{
    IEnumerable<Model.Employee> GetAll();
    Model.Employee? GetById(int id);
    int Add(Model.Employee employee);
    bool Edit(Model.Employee employee);
    bool Delete(int id);
}