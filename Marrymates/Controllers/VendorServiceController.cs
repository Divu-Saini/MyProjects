using MarryMatesDotNet.Models;
using MarryMatesDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarryMatesDotNet.Controllers
{
    public class VendorServiceController : Controller
    {
        private readonly IVendorServiceRepository _vendorServiceRepository;

        public VendorServiceController(IVendorServiceRepository vendorServiceRepository)
        {
            _vendorServiceRepository = vendorServiceRepository;
        }

        public IActionResult Index()
        {
            var services = _vendorServiceRepository.GetAllServices();
            return View(services);
        }

        public IActionResult Details(int id)
        {
            var service = _vendorServiceRepository.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendorService service)
        {
            Console.WriteLine(service.VendorId);
            Console.WriteLine(service.Description);
            Console.WriteLine(ModelState.IsValid);

            {
                _vendorServiceRepository.AddService(service);
                return RedirectToAction(nameof(Index));
            }
            //  return View(service);
        }

        public IActionResult Edit(int id)
        {
            var service = _vendorServiceRepository.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VendorService service)
        {
            if (!ModelState.IsValid)
            {
                // Log the errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(service);
            }

            _vendorServiceRepository.UpdateService(service);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var service = _vendorServiceRepository.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _vendorServiceRepository.DeleteService(id);
            return RedirectToAction(nameof(Index));
        }
    }
}