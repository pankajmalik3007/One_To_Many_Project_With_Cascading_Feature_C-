
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using O_T_M_POPUP_WITHCASCADE_SP.Models;

namespace O_T_M_POPUP_WITHCASCADE_SP.Mapper
{
    public class DepartmentMapper : IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Dep_ID)
               .HasName("pk_Dep_Id");

            builder.Property(e => e.Dep_ID)
              .ValueGeneratedOnAdd()
              .HasColumnName("Dept Id")
              .HasColumnType("INT");


            builder.Property(e => e.Dep_Name)
               .HasColumnName("Department Name")
               .HasColumnType("Nvarchar(100)")
               .IsRequired();
        }

    }
}
