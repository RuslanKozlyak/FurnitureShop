using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ShopCartItemConfiguration : IEntityTypeConfiguration<ShopCartItem>
    {
        public void Configure(EntityTypeBuilder<ShopCartItem> entityBuilder)
        {
            entityBuilder.HasKey(furniture => furniture.Id);
            entityBuilder.Property(author => author.ShopCartId);
        }
    }
}
