using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _User = MassTransit.SingUp.Domain.Aggregates.User;

namespace MassTransit.SingUp.Infrastructure.EntityFramework.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<_User>
    {
        public void Configure(EntityTypeBuilder<_User> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.BirthDate)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.CPF)
                .IsRequired();
            builder.Property(x => x.Phone);
        }
    }
}
