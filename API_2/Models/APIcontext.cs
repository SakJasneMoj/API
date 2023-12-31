using API_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_2.Models
{
	public class APIcontext : DbContext
	{

		public APIcontext(DbContextOptions<APIcontext> options)
	   : base(options)
		{
		}

		public DbSet<Company> Company { get; set; } = null!;
		public DbSet<Employees> Employees { get; set; } = null!;
		public DbSet<Division> Divisions { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Department> Departments { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Employees
			// Primary key
			modelBuilder.Entity<Employees>()
				.HasKey(e => e.EmployeeID);


			//atributes
			modelBuilder.Entity<Employees>()
			   .Property(e => e.FirstName)
			   .HasMaxLength(255);

			modelBuilder.Entity<Employees>()
			   .Property(e => e.LastName)
			   .HasMaxLength(255);

			modelBuilder.Entity<Employees>()
			   .Property(e => e.Phone)
			   .HasMaxLength(20);

			modelBuilder.Entity<Employees>()
			   .Property(e => e.Email)
			   .HasMaxLength(255);

			// Employees Relationships
			modelBuilder.Entity<Employees>()
				.HasOne(e => e.Company)
				.WithMany(c => c.Employees)
				.HasForeignKey(e => e.CompanyID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Employees>()
				.HasOne(e => e.Division)
				.WithMany(d => d.Employees)
				.HasForeignKey(e => e.DivisionID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Employees>()
				.HasOne(e => e.Project)
				.WithMany(p => p.Employees)
				.HasForeignKey(e => e.ProjectID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Employees>()
				.HasOne(e => e.Department)
				.WithMany(d => d.Employees)
				.HasForeignKey(e => e.DepartmentID)
				.OnDelete(DeleteBehavior.SetNull);








			//Company
			//Primary key
			modelBuilder.Entity<Company>()
				.HasKey(e => e.CompanyID);


			//atributes
			modelBuilder.Entity<Company>()
			   .Property(e => e.Code)
			   .HasMaxLength(50);

			modelBuilder.Entity<Company>()
			   .Property(e => e.Name)
			   .HasMaxLength(255);

			// Company Relationships
			modelBuilder.Entity<Company>()
				.HasOne<Employees>(c => c.Leader)
				.WithOne()
				.HasForeignKey<Company>(c => c.LeaderID)
				.OnDelete(DeleteBehavior.SetNull);




			// Division Configurations
			modelBuilder.Entity<Division>()
				.HasKey(d => d.DivisionID);
			modelBuilder.Entity<Division>()
				.Property(d => d.Code).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Division>()
				.Property(d => d.Name).IsRequired().HasMaxLength(255);

			// Division Relationships
			modelBuilder.Entity<Division>()
				.HasOne<Employees>(d => d.Leader)
				.WithOne()
				.HasForeignKey<Division>(d => d.LeaderID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Division>()
				.HasOne(d => d.Company)
				.WithMany(c => c.Divisions)
				.HasForeignKey(d => d.CompanyID)
				.OnDelete(DeleteBehavior.NoAction);





			// Project Configurations
			modelBuilder.Entity<Project>()
				.HasKey(p => p.ProjectID);
			modelBuilder.Entity<Project>()
				.Property(p => p.Code).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Project>()
				.Property(p => p.Name).IsRequired().HasMaxLength(255);


			// Project Relationships
			modelBuilder.Entity<Project>()
				.HasOne<Employees>(p => p.Leader)
				.WithOne()
				.HasForeignKey<Project>(p => p.LeaderID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Project>()
				.HasOne(p => p.Divisions)
				.WithMany(d => d.Projects)
				.HasForeignKey(p => p.DivisionID)
				.OnDelete(DeleteBehavior.NoAction);




			// Department Configurations
			modelBuilder.Entity<Department>()
				.HasKey(d => d.DepartmentID);
			modelBuilder.Entity<Department>()
				.Property(d => d.Code).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Department>()
				.Property(d => d.Name).IsRequired().HasMaxLength(255);

			// Department Relationships
			modelBuilder.Entity<Department>()
				.HasOne<Employees>(d => d.Leader)
				.WithOne()
				.HasForeignKey<Department>(d => d.LeaderID)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Department>()
				.HasOne(d => d.Project)
				.WithMany(p => p.Departments)
				.HasForeignKey(d => d.ProjectID)
				.OnDelete(DeleteBehavior.NoAction);


		}


	}
}
