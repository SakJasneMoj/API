using API_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_2.Models
{
	public class Company
	{
		public int CompanyID { get; set; }


		public string Code { get; set; }
		public string Name { get; set; }
		public int? LeaderID { get; set; }



		public Employees Leader { get; set; }
		

		// Collection of Employees
		public ICollection<Employees> Employees { get; set; }

		public ICollection<Division> Divisions { get; set; }


	}
}
