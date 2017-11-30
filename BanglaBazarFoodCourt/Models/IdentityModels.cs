using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BanglaBazarFoodCourt.Models.Entities;

namespace BanglaBazarFoodCourt.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> CustomerTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<Promo> PromoTable { get; set; }
        public DbSet<Food_Item> Food_ItemTable { get; set; }
        //DbSet<Employee> EmployeeTable { get; set; }
        public DbSet<Supervisor> SupervisorTable { get; set; }
        public DbSet<Discounts> DiscountTable { get; set; }
        public DbSet<Contains> Contains_Table { get; set; }
        public DbSet<Phone_Order> Phone_OrderTable { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BanglaBazarFoodCourt.Models.Entities.Employee> Employees { get; set; }
    }
}