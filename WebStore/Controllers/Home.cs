﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Model;

namespace WebStore.Controllers;

public class Home : Controller
{
    private static Employee[] employees = new[]
    {
        new Employee()
        {
            Id = 0, FirstName = "Илья", LastName = "Иванов", Patronymic = "Иванович", Age = 13, TotalDaysInCompany = 90
        },
        new Employee()
        {
            Id = 1, FirstName = "Максим", LastName = "Иванов", Patronymic = "Ильич", Age = 31, TotalDaysInCompany = 190
        },
        new Employee()
        {
            Id = 2, FirstName = "Софья", LastName = "Ива", Patronymic = "Максимовна", Age = 124, TotalDaysInCompany = 10
        },
        new Employee()
        {
            Id = 3, FirstName = "Илья", LastName = "Ивановов", Patronymic = "Иванович", Age = 32,
            TotalDaysInCompany = 230
        },
    };

    public IActionResult Index()
    {
        return View();
    }

    public string ConfiguredAction(string id, string arg0, string arg1)
    {
        return $"id - {id}\n" +
               $"v1 - {arg0}\n" +
               $"v2 - {arg1}";
    }

    public ViewResult GetEmployees()
    {
        return View(employees);
    }

    public ViewResult Info(int id)
    {
        return View(employees.FirstOrDefault(employee => employee.Id == id));
    }
}