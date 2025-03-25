using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class ParameterController : Controller
{
    private readonly ParameterService _parameterService;
    
    public ParameterController(ParameterService parameterService)
    {
        _parameterService = parameterService;
    }

    [HttpPost]
    public IActionResult Edit(Parameter parameter)
    {
        // if (parameter.parameterValue < 0 || parameter.parameterValue > 10)
        // {
        //     ModelState.AddModelError("parameterValue", "The parameter value must be between 0 and 10.");
        //     return View(parameter);
        // }
        _parameterService.UpdateParameterThresholdAlert(parameter.parameterValue);
        return RedirectToAction("Edit", "Parameter");
    }
    
    [HttpGet]
    public IActionResult Edit()
    {
        Parameter? parameter = _parameterService.GetParameterThresholdAlert();
        if (parameter == null)
        {
            parameter = new Parameter();
        }
        parameter.parameterKey = "threshold";
        parameter.parameterValue = parameter.parameterValue;
        return View(parameter);
    }
    
    
    
}