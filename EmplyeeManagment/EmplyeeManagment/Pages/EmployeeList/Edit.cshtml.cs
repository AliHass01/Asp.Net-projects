using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplyeeManagment.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmplyeeManagment.Pages.EmployeeList
{
	public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public Employee Employee { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Employee = await _db.Employee.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var EmployeeDb = await _db.Employee.FindAsync(Employee.Id);
                EmployeeDb.Name = Employee.Name;
                EmployeeDb.Salary = Employee.Salary;
                EmployeeDb.Position = Employee.Position;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
                return RedirectToPage();
        }
    }
}
