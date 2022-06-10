using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(furniture => furniture.Id);
            entityBuilder.Property(furniture => furniture.HumanId);
            entityBuilder.Property(furniture => furniture.FullCost);
            entityBuilder.Property(author => author.OrderTime);

            entityBuilder.HasOne(item => item.Human)
                .WithMany(prod => prod.Orders)
                .HasForeignKey(x=>x.HumanId);
        }
    }
}
