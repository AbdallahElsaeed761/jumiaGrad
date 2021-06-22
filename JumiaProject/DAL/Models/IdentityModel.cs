using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class IdentityModel
    {
    }
    public class applicationUser:IdentityUser
    {
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Fname { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Lanme { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Address { get; set; }
        [DefaultValue(true)]
        public string Adminlocked { get; set; }
        [StringLength(maximumLength: 6, MinimumLength = 1)]
        public string Gender { get; set; }
        [Range(18,100,ErrorMessage ="you should more than 0 or 18 and less than 100")]
        public byte Age { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
    
    public class ApplicationUserStore : UserStore<applicationUser>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }
    public class ApplicationUserManager : UserManager<applicationUser>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager() :
            base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db) :
            base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class ApplicationDBContext : IdentityDbContext<applicationUser>
    {
        public ApplicationDBContext() :
            base("Data Source =DESKTOP-GF4P384\\ABDALLAHSQL; Initial Catalog = Jumiamvc; Integrated Security = True")
        {

        }
        public virtual DbSet<Brand> Brands { get; set; }
        //public virtual DbSet<applicationUser> ApplicationUsers { get; set; }
        //public DbSet<T> Users { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetails { get; set; }
        public virtual DbSet<InventoryProduct> InventoryProducts { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<View> Views { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Employee>().ToTable("Employees");



            modelBuilder.Entity<View>().HasKey(v => new { v.CustomerId, v.ProductId });
            modelBuilder.Entity<Review>().HasKey(r => new { r.CustomerId, r.ProductId });
            modelBuilder.Entity<ProductImage>().HasKey(pi => new { pi.ProductId, pi.Image });
            modelBuilder.Entity<InventoryProduct>().HasKey(IP => new { IP.InventoryId, IP.ProductId });
           // modelBuilder.Entity<ShippingDetails>().HasRequired(r => r.Payment).WithRequiredDependent(p => p.ShippingDetail);
            



        }
    }
       
           
    
}
