using BL.Reporsities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        int Commit();
        AccountRepository Account { get; }
        BrandsRepository Brands { get; }
        CartItemRepository CartItem { get; }
        CartRepository Cart { get; }
        CategoryRepository Category { get; }
        ProductRepository Product { get; }
        RoleRepository Role { get; }
        PaymentRepsitory Payment { get; }
        ReviewRepository Review { get; }
        CustomerRepository Customer { get; }
        EmployeeRepository Employee { get; }
        GovernorateRepository Governorate { get; }
        InventoryRepository Inventory { get; }
        InventoryproductRepository Inventoryproduct { get; }
        ProductDetailsRepository ProductDetails { get; }
       
        ProductimageRepository Productimage { get; }
        PromotionRepository Promotion { get; }
       SellerRepository Seller { get; }
        ShippedDetailsRepository ShippedDetails { get; }
        StatusRepository Status { get; }
        SubCategoryRepository SubCategory { get; }
        ViewRepository View { get; }


    }
}
