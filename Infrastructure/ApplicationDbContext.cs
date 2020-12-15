using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.IServices;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService)
            : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Boat> Boats { get; set; }
        
        private const int CarId1 = 1;
        private const int CarId2 = 2;
        private const string UserId = "4ab306a9-ff4c-46ca-a6f9-c47383d928d8";

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // create user
            var user = new ApplicationUser
            {
                Id = UserId,
                UserName = "berik.assylbekov@gmail.com",
                NormalizedUserName = "berik.assylbekov@gmail.com".ToUpper(),
                Email = "berik.assylbekov@gmail.com",
                NormalizedEmail = "berik.assylbekov@gmail.com".ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //set user password
            var ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "CCc76511!!");
            modelBuilder.Entity<ApplicationUser>().HasData(user);
            
            modelBuilder.Entity<Vehicle>(ConfigureVehicle);
            modelBuilder.Entity<Car>(ConfigureCar);
            modelBuilder.Entity<Boat>(ConfigureBoat);
        }
        
        private void ConfigureVehicle(EntityTypeBuilder<Vehicle> modelBuilder)
        {
            modelBuilder.Property(a => a.Price).HasColumnType("decimal(10, 2)");
        }
        private void ConfigureCar(EntityTypeBuilder<Car> modelBuilder)
        {
            // populate initial data
            modelBuilder.ToTable("Cars");
            modelBuilder.HasData(new List<Car>()
            {
                new Car()
                {
                    Id = CarId1,
                    Created = DateTime.Now,
                    CreatedBy = UserId,
                    Make = "BMW",
                    Model = "M5",
                    VehicleType = VehicleType.Car,
                    OwnerId = UserId,
                    Engine = Guid.NewGuid().ToString(),
                    NumberOfDoors = 5,
                    NumberOfWheels = 4,
                    CarBodyType = CarBodyType.Sedan
                },
                new Car()
                {
                    Id = CarId2,
                    Created = DateTime.Now,
                    CreatedBy = UserId,
                    Make = "VW",
                    Model = "Passat",
                    VehicleType = VehicleType.Car,
                    OwnerId = UserId,
                    Engine = Guid.NewGuid().ToString(),
                    NumberOfDoors = 5,
                    NumberOfWheels = 4,
                    CarBodyType = CarBodyType.Hatchback
                }
            });
        }
        
        private void ConfigureBoat(EntityTypeBuilder<Boat> modelBuilder)
        {
            modelBuilder.ToTable("Boats");
        }
    }
}