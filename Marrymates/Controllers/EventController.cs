


using MarryMatesDotNet.Models;
using MarryMatesDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarryMatesDotNet.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVenueRepository _venueRepository;

        public EventController(IEventRepository eventRepository, IUserRepository userRepository, IVenueRepository venueRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _venueRepository = venueRepository;
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewBag.Clients = _userRepository.GetClients();  
            ViewBag.Vendors = _userRepository.GetVendors();  
            ViewBag.Venues = _venueRepository.GetAllVenues();   

            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.AddEvent(model); 
                return RedirectToAction(nameof(Index)); 

            }

            
            ViewBag.Clients = _userRepository.GetClients(); 
            ViewBag.Vendors = _userRepository.GetVendors();  
            ViewBag.Venues = _venueRepository.GetAllVenues();    

            return View(model);

        }



        // --------------------------




        //---------------------------

        // GET: Event/Index
        public IActionResult Index()
        {
            var events = _eventRepository.GetAllEvents(); 
            return View(events);
        }

        // GET: Event/Details/ID
        public IActionResult Details(int id)
        {
            var eventModel = _eventRepository.GetEventById(id); 
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // GET: Event/Edit/ID
        public IActionResult Edit(int id)
        {
            var eventModel = _eventRepository.GetEventById(id); 
            if (eventModel == null)
            {
                return NotFound();
            }

            ViewBag.Clients = _userRepository.GetClients();  
            ViewBag.Vendors = _userRepository.GetVendors();  
            ViewBag.Venues = _venueRepository.GetAllVenues();     

            return View(eventModel);
        }

        // POST: Event/Edit/ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Event model)
        {
            if (id != model.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _eventRepository.UpdateEvent(model);
                return RedirectToAction(nameof(Index)); 
            }

            ViewBag.Clients = _userRepository.GetClients(); 
            ViewBag.Vendors = _userRepository.GetVendors();  
            ViewBag.Venues = _venueRepository.GetAllVenues();   

            return View(model);
        }

        // GET: Event/Delete/ID
        public IActionResult Delete(int id)
        {
            var eventModel = _eventRepository.GetEventById(id); 
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // POST: Event/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _eventRepository.DeleteEvent(id); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
