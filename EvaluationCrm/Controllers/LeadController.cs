using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers
{
    public class LeadController : Controller
    {
        private readonly LeadService _leadService;

        public LeadController(LeadService service)
        {
            _leadService = service;
        }
        public IActionResult Index()
        {
            List<Lead>? leads = _leadService.GetLeads();
            return View(leads);
        }

        public IActionResult Delete(Int16 leadId)
        {
            _leadService.DeleteLead(leadId);
            return RedirectToAction("Index");
        }
        
    }
}