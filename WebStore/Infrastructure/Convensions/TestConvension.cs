using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebStore.Infrastructure.Convensions;

public class TestConvension : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        Debug.WriteLine($"* {controller.ControllerName}");
    }
}