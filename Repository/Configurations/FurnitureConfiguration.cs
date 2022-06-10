using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FurnitureConfiguration : IEntityTypeConfiguration<Furniture>
    {
        public void Configure(EntityTypeBuilder<Furniture> entityBuilder)
        {
            entityBuilder.HasKey(furniture => furniture.Id);
            entityBuilder.Property(author => author.ProductName).IsRequired();
            entityBuilder.Property(author => author.Quantity).IsRequired();
            entityBuilder.Property(author => author.Cost).IsRequired();
            entityBuilder.Property(author => author.Size).IsRequired();
            entityBuilder.Property(author => author.Weight).IsRequired();
            entityBuilder.Property(author => author.ShortDescription).IsRequired();
            entityBuilder.Property(author => author.LongDescription).IsRequired();
            entityBuilder.Property(author => author.CartItemId);
            entityBuilder.Property(author => author.CategoryId);
            entityBuilder.Property(author => author.Img).IsRequired();

            entityBuilder.HasOne(item => item.Category)
                .WithMany(prod => prod.Furnitures)
                .HasForeignKey(prod => prod.CategoryId);

            entityBuilder.HasOne(book => book.OrderDatails)
             .WithOne(author => author.Furniture)
             .HasForeignKey<OrderDatails>(x => x.ProductId);

            entityBuilder.HasOne(book => book.ShopCartItem)
             .WithOne(author => author.Furnitures)
             .HasForeignKey<Furniture>(x => x.CartItemId);
        }
    }
}
