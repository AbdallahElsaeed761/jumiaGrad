using BL.Interfaces;
using BL.Reporsities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Basices
{
    public class UnitOfWork:IUnitofWork
    {
        private DbContext EC_DbContext { get; set; }
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public AccountRepository accountRepository;
        public AccountRepository Account
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(EC_DbContext);
                return accountRepository;
            }
        }



        public BrandsRepository brandsRepository;
        public BrandsRepository Brands
        {
            get
            {
                if (brandsRepository == null)
                    brandsRepository = new BrandsRepository(EC_DbContext);
                return brandsRepository;
            }
        }
        public CartItemRepository CartItemRepository;
        public CartItemRepository CartItem
        {
            get
            {
                if (CartItemRepository == null)
                    CartItemRepository = new CartItemRepository(EC_DbContext);
                return CartItemRepository;
            }
        }

        public CartRepository cartRepository;
        public CartRepository Cart
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new CartRepository(EC_DbContext);
                return cartRepository;
            }
        }


        public CategoryRepository categoryRepository;
        public CategoryRepository Category
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(EC_DbContext);
                return categoryRepository;
            }
        }

        public ProductRepository productRepository;
        public ProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(EC_DbContext);
                return productRepository;
            }
        }

        public RoleRepository roleRepository;
        public RoleRepository Role
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(EC_DbContext);
                return roleRepository;
            }
        }

        public PaymentRepsitory paymentRepository;
        public PaymentRepsitory Payment
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepsitory(EC_DbContext);
                return paymentRepository;
            }
        }

        public ReviewRepository reviewRepository;
            public ReviewRepository Review 
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(EC_DbContext);
                return reviewRepository;
            }
        }

        public CustomerRepository customerRepository;

        public CustomerRepository Customer
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(EC_DbContext);
                return customerRepository;
            }
        }
        public EmployeeRepository EmployeeRepository;

        public EmployeeRepository Employee
        {
            get
            {
                if (EmployeeRepository==null)
                    EmployeeRepository = new EmployeeRepository(EC_DbContext);
                return EmployeeRepository;
            }
        }

        public GovernorateRepository governorateRepository;
        public GovernorateRepository Governorate
        {
            get
            {
                if (governorateRepository == null)
                    governorateRepository = new GovernorateRepository(EC_DbContext);
                return governorateRepository;
            }
        }

        public InventoryRepository inventoryRepository;

        public InventoryRepository Inventory
        {
            get
            {
                if (inventoryRepository == null)
                    inventoryRepository = new InventoryRepository(EC_DbContext);
                return inventoryRepository;
            }
        }
        public InventoryproductRepository inventoryproductRepository;

        public InventoryproductRepository Inventoryproduct
        {
            get
            {
                if (inventoryproductRepository == null)
                    inventoryproductRepository = new InventoryproductRepository(EC_DbContext);
                return inventoryproductRepository;
            }
        }
        public ProductDetailsRepository productDetailsRepository;

        public ProductDetailsRepository ProductDetails
        {
            get
            {
                if (productDetailsRepository == null)
                    productDetailsRepository = new ProductDetailsRepository(EC_DbContext);
                return productDetailsRepository;
            }
        }
        public ProductimageRepository productimageReposotory;


        public ProductimageRepository Productimage
        {
            get
            {
                if (productimageReposotory == null)
                    productimageReposotory = new ProductimageRepository(EC_DbContext);
                return productimageReposotory;
            }

        }

        public PromotionRepository promotionRepository;

        public PromotionRepository Promotion
        {
            get
            {
                if (promotionRepository == null)
                    promotionRepository = new PromotionRepository(EC_DbContext);
                return promotionRepository;
            }
        }

        public SellerRepository sellerRepository;

        public SellerRepository Seller
        {
            get
            {
                if (sellerRepository == null)
                    sellerRepository = new SellerRepository(EC_DbContext);
                return sellerRepository;
            }
        }
        public ShippedDetailsRepository shippedDetailsRepository;


        public ShippedDetailsRepository ShippedDetails
        {
            get
            {
                if (shippedDetailsRepository == null)
                    shippedDetailsRepository = new ShippedDetailsRepository(EC_DbContext);
                return shippedDetailsRepository;
            }
        }
        public StatusRepository statusRepository;

        public StatusRepository Status
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(EC_DbContext);
                return statusRepository;
            }
        }
        public SubCategoryRepository subCategoryRepository;

        public SubCategoryRepository SubCategory
        {
            get
            {
                if (subCategoryRepository == null)
                    subCategoryRepository = new SubCategoryRepository(EC_DbContext);
                return subCategoryRepository;
            }
        }
        public ViewRepository ViewRepository;

        public ViewRepository View
        {
            get
            {
                if (ViewRepository == null)
                    ViewRepository = new ViewRepository(EC_DbContext);
                return ViewRepository;
            }
        }

       

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
    }
}
