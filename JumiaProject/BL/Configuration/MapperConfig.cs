using AutoMapper;
using BL.ViewModels;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configuration
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    
                    
                    cfg.CreateMap<Cart, CartViewModel>().ReverseMap();
                    cfg.CreateMap<CartItem, CartItemViewModel>().ReverseMap();
                    cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                    cfg.CreateMap<Payment, PaymentViewModel>().ReverseMap();
                    cfg.CreateMap<Review, ReviewViewModel>().ReverseMap();
                    cfg.CreateMap<Brand, BrandViewModel>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<applicationUser, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<applicationUser, RegisterViewModel>().ReverseMap();
                    cfg.CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
                    cfg.CreateMap<IdentityUserRole, RoleViewModel>().ReverseMap();

                    cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
                    cfg.CreateMap<Employee,EmployeeModelView>().ReverseMap();
                    cfg.CreateMap<Governorate, GovernorateViewModel>().ReverseMap();
                    cfg.CreateMap<Inventory, inventoryViewModel>().ReverseMap();
                    cfg.CreateMap<InventoryProduct, InventoryproductViewModel>().ReverseMap();

                    cfg.CreateMap<ProductDetail, ProductDetailsViewModel>().ReverseMap();
                    cfg.CreateMap<ProductImage, productImageViewModel>().ReverseMap();
                    
                    cfg.CreateMap<Seller, SellerViewModel>().ReverseMap();
                    cfg.CreateMap<ShippingDetails, ShippingDetailsViewModel>().ReverseMap();
                    cfg.CreateMap<Status, StatusViewModel>().ReverseMap();
                    cfg.CreateMap<SubCategory, SubCategoryViewModel>().ReverseMap();
                    cfg.CreateMap<Promotions, PromotionViewModel>().ReverseMap();


                    cfg.CreateMap<View, ViewsViewModel>().ReverseMap();
                    cfg.CreateMap<applicationUser, ResetpasswordViewModel>().ReverseMap();
                    



                });
            Mapper = config.CreateMapper();
        }
    }
}
