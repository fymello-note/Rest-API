using CompanyEmployees.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.Configuration
{
    public class ApiUserConfiguration : IEntityTypeConfiguration<ApiUser> {
        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            builder.HasData(
                new ApiUser
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    UserName = "user1",
                    Password = "psww1"
                }
            );
        }
    }
}