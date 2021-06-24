using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JumiaWebApiGrad.Controllers
{
    public class BrandController : ApiController
    {
         BrandsAppServices _brandsAppServices;
        public BrandController()
        {

        }

        public BrandController(BrandsAppServices brandsAppServices)
        {
            _brandsAppServices = brandsAppServices;
        }
        public IHttpActionResult GetAllBrand()
        {
            return Ok(_brandsAppServices.GetAllBrands());
        }
        public IHttpActionResult GetBrandById(int id)
        {
            var result = _brandsAppServices.GetBrand(id);
            if (result == null)
                return NotFound();
            return Ok();
        }
    }
}
