using MarryMatesDotNet.Models;
using MarryMatesDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarryMatesDotNet.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepository _venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public IActionResult Index()
        {
            var venues = _venueRepository.GetAllVenues();
            return View(venues);
        }

        public IActionResult Details(int id)
        {
            var venue = _venueRepository.GetVenueById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _venueRepository.AddVenue(venue);
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Edit(int id)
        {
            var venue = _venueRepository.GetVenueById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _venueRepository.UpdateVenue(venue);
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Delete(int id)
        {
            var venue = _venueRepository.GetVenueById(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _venueRepository.DeleteVenue(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
