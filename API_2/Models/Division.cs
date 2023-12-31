using API_2.Models;

namespace API_2.Models
{
	public class Division
	{
		//primary key 
		public int DivisionID { get; set; }

		//atributes
		public string Code { get; set; }
		public string Name { get; set; }

		//foreign keys
		// Nullable foreign key for the leader
		public int? LeaderID { get; set; }

		// Foreign key for Company
		public int CompanyID { get; set; }

		// Navigation properties
		public Employees Leader { get; set; }
		public Company Company { get; set; }
		
		public ICollection<Project> Projects { get; set; } // A Division can have multiple Projects
		public ICollection<Employees> Employees { get; set; } // Employees in this Division


	}
}
