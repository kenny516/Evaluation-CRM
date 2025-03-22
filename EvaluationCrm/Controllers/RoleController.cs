using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class RoleController : Controller
{
    private readonly RoleService _roleService;
    
    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }
    
    // GET
    public IActionResult Index()
    {
         List<Role> roles = _roleService.GetAllRoles();
        return View(roles);
    }
}