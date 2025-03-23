using EvaluationCrm.Models.entity;
using EvaluationCrm.service;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationCrm.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        public IActionResult Index()
        {
            List<Ticket>? tickets = _ticketService.GetTickets();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Delete(Int16 ticketId)
        {
            _ticketService.DeleteTicket(ticketId);
            return RedirectToAction("Index");
        }
    }
}