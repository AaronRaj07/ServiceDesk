using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Controllers
{
    public class TicketController : Controller
    {
        private readonly ServiceDeskContext _context;

        public TicketController(ServiceDeskContext context)     
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tickets = _context.Ticket.ToList();
            return View(tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if(ModelState.IsValid)
            {
                _context.Ticket.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var ticket = _context.Ticket.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ticket ticket)
        {
            if(id != ticket.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Ticket.Update(ticket);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }
        
        public IActionResult Delete(int id)
        {
            var ticket = _context.Ticket.Find(id);
            if(ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ticket = _context.Ticket.Find(id);
            if(ticket != null)
            {
                _context.Ticket.Remove(ticket);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}