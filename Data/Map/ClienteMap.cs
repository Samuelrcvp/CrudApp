using CrudApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Crypto.Tls;

namespace CrudApp.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(100);
            builder.Property(x => x.Celular).HasMaxLength(25);
            builder.Property(x => x.Email).HasMaxLength(256);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }
    }
}
