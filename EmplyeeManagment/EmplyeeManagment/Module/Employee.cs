using System;
using System.ComponentModel.DataAnnotations;

namespace EmplyeeManagment.Module
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public double Salary { get; set; }
		public string Position { get; set; }

		public Employee()
		{
		}
	}
}

