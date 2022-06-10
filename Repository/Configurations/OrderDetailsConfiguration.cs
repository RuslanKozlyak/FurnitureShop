using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDatails>
    {
        public void Configure(EntityTypeBuilder<OrderDatails> entityBuilder)
        {
            entityBuilder.HasKey(furniture => furniture.Id);
            entityBuilder.Property(author => author.OrderId);
            entityBuilder.Property(author => author.ProductId);

            entityBuilder.HasOne(item => item.Order)
                .WithMany(prod => prod.OrderDatails)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
