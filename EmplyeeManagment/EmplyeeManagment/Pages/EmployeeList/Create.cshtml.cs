﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplyeeManagment.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmplyeeManagment.Pages.EmployeeList
{
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Employee.AddAsync(Employee);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
    }
}
