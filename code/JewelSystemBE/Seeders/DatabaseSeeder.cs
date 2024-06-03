using JewelSystemBE.Model;
using Microsoft.EntityFrameworkCore;

namespace JewelSystemBE.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jewel>().HasData(
                new Jewel(){ Id = 1, Name = "Gold", IsComplete = true },
                new Jewel() { Id = 8, Name = "Diamond", IsComplete = true },
                new Jewel() { Id = 3, Name = "Black Gol", IsComplete = false }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = "admin",
                    Password = "12345",
                    Fullname = "Administrator",
                    Email = "admin@example.com",
                    Role = "Admin"
                },
            new User
            {
                UserId = Guid.NewGuid().ToString(),
                Username = "user1",
                Password = "12345",
                Fullname = "John Doe",
                Email = "john.doe@example.com",
                Role = "User"
            },
            new User
            {
                UserId = Guid.NewGuid().ToString(),
                Username = "user2",
                Password = "12345",
                Fullname = "Jane Smith",
                Email = "jane.smith@example.com",
                Role = "User"
            },
            new User
            {
                UserId = Guid.NewGuid().ToString(),
                Username = "user3",
                Password = "12345",
                Fullname = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Role = "User"
            },
            new User
            {
                UserId = Guid.NewGuid().ToString(),
                Username = "user4",
                Password = "12345",
                Fullname = "Bob Brown",
                Email = "bob.brown@example.com",
                Role = "User"
            }
                );
        }
    }
}
