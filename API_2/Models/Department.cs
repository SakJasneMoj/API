using API_2.Models;

namespace API_2.Models
{
	public class Department
	{
		public int DepartmentID { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }

		// Nullable foreign key for the leader
		public int? LeaderID { get; set; }

		// Foreign key for Project
		public int ProjectID { get; set; }

		// Navigation properties
		public Employees Leader { get; set; }
		public Project Project { get; set; }
		public ICollection<Employees> Employees { get; set; } // Employees in this Department

		
	}

}
