﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using O_T_M_POPUP_WITHCASCADE_SP.Models;

namespace O_T_M_POPUP_WITHCASCADE_SP.Mapper
{
    public class StateMapper : IEntityTypeConfiguration<State>
    {

        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(e => e.StateId)
             .HasName("pk_StateId");

            builder.Property(e => e.StateId)
               .ValueGeneratedOnAdd()
               .HasColumnName("State Id")
               .HasColumnType("INT");

            builder.Property(e => e.StateName)
             .HasColumnName("State Name")
             .HasColumnType("Nvarchar(100)")
             .IsRequired();

            builder.HasOne<Country>(c => c.Country)
              .WithMany(d => d.states)
              .HasForeignKey(d => d.CountryId)
              .OnDelete(DeleteBehavior.Restrict);


        }
        
        }
}
