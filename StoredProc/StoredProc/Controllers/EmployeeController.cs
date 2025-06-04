using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProc.Data;
using StoredProc.Models;

namespace StoredProc.Controllers
{
    public class EmployeeController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _confiq { get; }

        public EmployeeController
            (
                StoredProcDbContext context,
                IConfiguration confiq
            )
        {
            _context = context;
            _confiq = confiq;
        }


        public IActionResult Index()
        {
            return View();
        }

        //teha sp andmebaasi, mis annab andmed t;;tajatest
        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employees
                .FromSqlRaw<Employee>("spSearchEmployees")
                .ToList();

            return result;
        }
    }
}
