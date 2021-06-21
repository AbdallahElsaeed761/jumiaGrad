namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 50),
                        Isdeleted = c.Boolean(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Price = c.Single(nullable: false),
                        Discount = c.Double(),
                        RangeDate = c.String(),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Details = c.String(nullable: false),
                        Manufacture = c.String(nullable: false, maxLength: 20),
                        Rate = c.Double(nullable: false),
                        Size = c.String(nullable: false, maxLength: 50),
                        Color = c.String(nullable: false),
                        QuantitySealed = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        BrandId = c.Int(nullable: false),
                        SubCategotyId = c.Int(nullable: false),
                        PromotionId = c.Int(),
                        IsdeletedBySeller = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategotyId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.SubCategotyId)
                .Index(t => t.PromotionId);
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.InventoryId, t.ProductId })
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        BuildingNumber = c.String(nullable: false),
                        sellerId = c.String(maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Sellers", t => t.sellerId)
                .Index(t => t.sellerId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.String(nullable: false, maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                        NationalCard = c.String(),
                        Contract = c.String(),
                        TaxCard = c.String(),
                        CommercialRegistryCard = c.String(),
                        StoreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SellerId)
                .ForeignKey("dbo.AspNetUsers", t => t.SellerId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(nullable: false, maxLength: 20),
                        Lanme = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 20),
                        Adminlocked = c.String(),
                        Gender = c.String(maxLength: 6),
                        Age = c.Byte(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionsId = c.Int(nullable: false, identity: true),
                        Discount = c.Single(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        StatusControlled = c.String(nullable: false, maxLength: 30),
                        Isdeleted = c.Boolean(nullable: false),
                        SellerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PromotionsId)
                .ForeignKey("dbo.Sellers", t => t.SellerId)
                .Index(t => t.SellerId);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ProductDetailId = c.Int(nullable: false, identity: true),
                        Detail = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Image = c.String(nullable: false, maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Image })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        review = c.Double(),
                        comment = c.String(),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.ProductId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        Cost = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ShippingDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        CustomerID = c.String(maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        Isdeleted = c.Boolean(nullable: false),
                        hireDate = c.DateTime(nullable: false),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 30),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        IsFav = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.ProductId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Governorates",
                c => new
                    {
                        GovernorateId = c.Int(nullable: false, identity: true),
                        GovernorateName = c.String(nullable: false, maxLength: 30),
                        Duration = c.Int(nullable: false),
                        ShippingValue = c.Single(nullable: false),
                        Isdeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GovernorateId);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingDetailId = c.Int(nullable: false, identity: true),
                        PurshaesCost = c.Single(nullable: false),
                        GovernorateId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                        Carts_CartId = c.Int(),
                    })
                .PrimaryKey(t => t.ShippingDetailId)
                .ForeignKey("dbo.Carts", t => t.Carts_CartId)
                .ForeignKey("dbo.Governorates", t => t.GovernorateId, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.GovernorateId)
                .Index(t => t.PaymentId)
                .Index(t => t.Carts_CartId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        amount = c.Single(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubCategoryBrands",
                c => new
                    {
                        SubCategory_SubCategoryId = c.Int(nullable: false),
                        Brand_BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategory_SubCategoryId, t.Brand_BrandId })
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_SubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandId, cascadeDelete: true)
                .Index(t => t.SubCategory_SubCategoryId)
                .Index(t => t.Brand_BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ShippingDetails", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.ShippingDetails", "GovernorateId", "dbo.Governorates");
            DropForeignKey("dbo.ShippingDetails", "Carts_CartId", "dbo.Carts");
            DropForeignKey("dbo.Products", "SubCategotyId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.SubCategoryBrands", "Brand_BrandId", "dbo.Brands");
            DropForeignKey("dbo.SubCategoryBrands", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Reviews", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Views", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Views", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Carts", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Carts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Carts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Customers", "CustomerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryProducts", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.Promotions", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "SellerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.SubCategoryBrands", new[] { "Brand_BrandId" });
            DropIndex("dbo.SubCategoryBrands", new[] { "SubCategory_SubCategoryId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ShippingDetails", new[] { "Carts_CartId" });
            DropIndex("dbo.ShippingDetails", new[] { "PaymentId" });
            DropIndex("dbo.ShippingDetails", new[] { "GovernorateId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Views", new[] { "ProductId" });
            DropIndex("dbo.Views", new[] { "CustomerId" });
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.Carts", new[] { "StatusId" });
            DropIndex("dbo.Carts", new[] { "EmployeeId" });
            DropIndex("dbo.Carts", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CustomerId" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Reviews", new[] { "CustomerId" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.Promotions", new[] { "SellerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sellers", new[] { "SellerId" });
            DropIndex("dbo.Inventories", new[] { "sellerId" });
            DropIndex("dbo.InventoryProducts", new[] { "ProductId" });
            DropIndex("dbo.InventoryProducts", new[] { "InventoryId" });
            DropIndex("dbo.Products", new[] { "PromotionId" });
            DropIndex("dbo.Products", new[] { "SubCategotyId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.SubCategoryBrands");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Governorates");
            DropTable("dbo.Categories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Views");
            DropTable("dbo.Status");
            DropTable("dbo.Employees");
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
            DropTable("dbo.Customers");
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Promotions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sellers");
            DropTable("dbo.Inventories");
            DropTable("dbo.InventoryProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
