
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using O_T_M_POPUP_WITHCASCADE_SP.Models;

namespace O_T_M_POPUP_WITHCASCADE_SP.Mapper
{
    public class EmployeeMapper : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Emp_ID)
                .HasName("pk_Employee_Id");

            builder.Property(e => e.Emp_ID)
                .ValueGeneratedOnAdd()
                .HasColumnName("Employee Id")
                .HasColumnType("INT");

            builder.Property(e => e.Emp_name)
                .HasColumnName("Employee Name")
                .HasColumnType("Nvarchar(100)")
                .IsRequired();

            builder.Property(e => e.Sallary)
                .HasColumnName("Employee Sallary")
                .HasColumnType("NVarchar(500)")
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasColumnName("Employee Gender")
                .HasColumnType("NVarchar(500)")
                .IsRequired();

          

           


            builder.HasOne<Department>(d => d.department)
               .WithMany(e => e.Employees)
               .HasForeignKey(f => f.Dep_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<State>(d => d.State)
                .WithMany(e => e.Employees)
                .HasForeignKey(f => f.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>(d => d.City)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(f => f.CityId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Country>(d => d.Country)
                .WithMany(d => d.employees)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
