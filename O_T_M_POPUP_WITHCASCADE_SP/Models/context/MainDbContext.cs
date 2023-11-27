using Demo.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using O_T_M_POPUP_WITHCASCADE_SP.Mapper;
using System.Reflection.Emit;


namespace O_T_M_POPUP_WITHCASCADE_SP.Models.context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne<Department>(d => d.department)
               .WithMany(e => e.Employees)
               .HasForeignKey(f => f.Dep_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasOne<State>(d => d.State)
                .WithMany(e => e.Employees)
                .HasForeignKey(f => f.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasOne<City>(d => d.City)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(f => f.CityId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasOne<Country>(d => d.Country)
                .WithMany(d => d.employees)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<State>()
                .HasOne<Country>(c => c.Country)
              .WithMany(d => d.states)
              .HasForeignKey(d => d.CountryId)
              .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<City>()
                .HasOne<State>(d => d.State)
                .WithMany(e => e.Cities)
                .HasForeignKey(f => f.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            /*builder.ApplyConfiguration(new EmployeeMapper());
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new DepartmentMapper());
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StateMapper());
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CityMapper());
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CountryMapper());
            base.OnModelCreating(builder);*/

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Department>().ToTable("Departments");
           
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<State>().ToTable("States");
            builder.Entity<Country>().ToTable("Countries");
           
        }

        public async Task<string> InsertOrUpdateEmployee(int empId, string empName, string gender, string salary, int depId, int stateid, int cityid, int countryid)
        {


            var pEmpId = new SqlParameter("@Emp_ID", empId);
            var Pempname = new SqlParameter("@Emp_name", empName);
            var Pgender = new SqlParameter("@Gender", gender);
            var Psalary = new SqlParameter("@Sallary", salary);
            var Pdepid = new SqlParameter("@Dep_ID", depId);
            var Pststeid = new SqlParameter("@StateId", stateid);
            var Pcityid = new SqlParameter("@CityId", cityid);
            var Pcountryid = new SqlParameter("@CountryId", countryid);
            var result = await Database.ExecuteSqlRawAsync("InsertOrUpdateEmployee @Emp_ID, @Emp_name, @Gender, @Sallary, @Dep_ID, @StateId, @CityId, @CountryId",
                pEmpId, Pempname, Pgender, Psalary, Pdepid, Pststeid, Pcityid, Pcountryid);
            return result == 1 ? "S" : "E";
        }

        public async Task<string> DeleteEmployee(int empId)
        {
            var pEmpId = new SqlParameter("@Emp_ID", empId);
            var result = await Database.ExecuteSqlRawAsync("DeleteEmployee @Emp_ID", pEmpId);

            return result == 1 ? "S" : "E";
        }

        public async Task<string> InsertOrUpdateDepartment(int depId, string depName)
        {
            var pDepId = new SqlParameter("@Dep_ID", depId);
            var pDepName = new SqlParameter("@Dep_Name", depName);
            var result = await Database.ExecuteSqlRawAsync("InsertOrUpdateDepartment @Dep_ID, @Dep_Name", pDepId, pDepName);

            return result == 1 ? "S" : "E";
        }
        public async Task<string> DeleteDepartment(int depId)
        {
            var pDepId = new SqlParameter("@Dep_ID", depId);
            var result = await Database.ExecuteSqlRawAsync("DeleteDepartment @Dep_ID", pDepId);

            return result == 1 ? "S" : "E";
        }

    }
}
