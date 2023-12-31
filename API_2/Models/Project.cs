using API_2.Models;

namespace API_2.Models
{
	public class Project
	{
		
			public int ProjectID { get; set; }


			public string Code { get; set; }
			public string Name { get; set; }
			public int? LeaderID { get; set; }
			public int? DivisionID { get; set; }	


			public Employees Leader { get; set; }

			public Division Divisions { get; set; }	
			// Collection of Employees
			public ICollection<Employees> Employees { get; set; } // Employees working on this Project
			public ICollection<Department> Departments { get; set; }	
	}



	}

