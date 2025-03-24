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
    public async Task<IActionResult> Login(string email)
    {
        var user = await _userService.GetUserByEmail(email);
        if (user != null)
        {
            return RedirectToAction("Index", "Dashboard");
        }
        ModelState.AddModelError(string.Empty, "Email invalide");
        return View("Index");
    }
}