using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Models.Models;

namespace WizLib_DataAcces.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Author_Id);
            modelBuilder.Property(b => b.LastName).IsRequired();
            modelBuilder.Property(b => b.FirstName).IsRequired();
            modelBuilder.Ignore(b => b.FullName);
        }
    }
}
