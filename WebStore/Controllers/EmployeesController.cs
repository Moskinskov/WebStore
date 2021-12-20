using Microsoft.AspNetCore.Mvc;
using WebStore.Model;
using WebStore.Services.Employee;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class Employees : Controller
{
    private readonly IEmployeesService employeesService;

    public Employees(IEmployeesService employeesService)
    {
        this.employeesService = employeesService;
    }

    public IActionResult Index()
    {
        return View(employeesService.GetAll());
    }

    public IActionResult Details(int id)
    {
        Employee? model = employeesService.GetById(id);
        return model is null ? NotFound() : View(model);
    }

    public IActionResult Edit(int id)
    {
        Employee? model = employeesService.GetById(id);

        if (model is null) return NotFound();

        EmployeeEditViewModel viewModel = new EmployeeEditViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Age = model.Age
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(EmployeeEditViewModel viewModel)
    {
        var employee = new Employee()
        {
            Id = viewModel.Id,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Patronymic = viewModel.Patronymic,
            Age = viewModel.Age
        };

        if (!employeesService.Edit(employee)) return NotFound();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        if (id < 0) return BadRequest();

        Employee? model = employeesService.GetById(id);
        if (model is null) return NotFound();

        EmployeeEditViewModel viewModel = new EmployeeEditViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Age = model.Age
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        if (!employeesService.Delete(id)) return NotFound();

        return RedirectToAction(nameof(Index));
    }
}