using API_2.Models;
using System.ComponentModel.DataAnnotations;

namespace API_2.Models
{
	public class Employees
	{
		//primaty key
		public int EmployeeID { get; set; }

		//atributes
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		//foreign keys
		public int? CompanyID { get; set; }
		public int? DivisionID { get; set; }
		public int? ProjectID { get; set; }
		public int? DepartmentID { get; set; }



		//navigation property
		public Company? Company { get; set; }
		public Division? Division { get; set; }
		public Project? Project { get; set; }
		public Department? Department { get; set; }

	}
}
