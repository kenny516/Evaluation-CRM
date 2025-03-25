using System.Text.Json;
using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers;

public class LoginController : Controller
{
    private readonly UserService _userService;

    public LoginController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(string email,string password)
    {
        var user = await _userService.Login(email,password);
        if (user != null)
        {
           HttpContext.Session.SetString("currentUser",JsonSerializer.Serialize(user));
           // var current = HttpContext.Session.GetString("currentUser");
           // var currentUser = JsonSerializer.Deserialize<User>(current);
            return RedirectToAction("Index", "Dashboard");
        }
        ModelState.AddModelError(string.Empty, "Email invalide Or not exist");
        return View("Index");
    }
}