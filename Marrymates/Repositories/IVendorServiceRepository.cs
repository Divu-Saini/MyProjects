using MarryMatesDotNet.Models;

namespace MarryMatesDotNet.Repositories
{
    public interface IVendorServiceRepository
    {
        IEnumerable<VendorService> GetAllServices();
        VendorService GetServiceById(int id);
        void AddService(VendorService service);
        void UpdateService(VendorService service);
        void DeleteService(int id);
    }
}
