using cadastro_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cadastro_api.Data.Map
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Tel).IsRequired().HasMaxLength(20);
        }
    }
}
