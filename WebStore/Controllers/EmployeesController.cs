using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Model;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class Employees : Controller
{
    private readonly IEnumerable<Employee> employees;

    public Employees()
    {
        employees = TestData.Employees;
    }

    public IActionResult Index()
    {
        return View(employees);
    }

    public IActionResult Details(int id)
    {
        Employee? model = employees.FirstOrDefault(employee => employee.Id == id);
        return model is null ? NotFound() : View(model);
    }

    // public IActionResult Create() => View();

    public IActionResult Edit(int id)
    {
        Employee? model = employees.FirstOrDefault(employee => employee.Id == id);

        EmployeeEditViewModel viewModel = new EmployeeEditViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Age = model.Age
        };

        return model is null ? NotFound() : View(viewModel);
    }

    public IActionResult Edit(EmployeeEditViewModel viewModel)
    {
        // обработка входящей информации
        
        Employee? editable = employees.FirstOrDefault(employee => employee.Id == viewModel.Id);
        editable.FirstName = viewModel.FirstName;
        editable.LastName = viewModel.LastName;
        editable.Patronymic = viewModel.Patronymic;
        editable.Age = viewModel.Age;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id) => View();
}