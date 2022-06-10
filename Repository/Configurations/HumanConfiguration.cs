using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> entityBuilder)
        {
            entityBuilder.HasKey(human => human.Id);
            entityBuilder.Property(human => human.FirstName).IsRequired();
            entityBuilder.Property(human => human.LastName).IsRequired();
            entityBuilder.Property(human => human.MiddleName);
            entityBuilder.Property(human => human.Adress);
            entityBuilder.Property(human => human.Phone);
            entityBuilder.Property(human => human.Email);
            entityBuilder.Property(human => human.Password);
        }
    }
}
