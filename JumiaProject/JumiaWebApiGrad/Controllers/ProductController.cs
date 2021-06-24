using BL.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JumiaWebApiGrad.Controllers
{
    public class ProductController : ApiController
    {
         ProductAppServices _productAppServices;

        public ProductController(ProductAppServices productAppServices)
        {
            this._productAppServices = productAppServices;
        }
        [HttpGet]
        public IHttpActionResult GetAllProduct()
        {
            var res = _productAppServices.GetAllProduct();
            if (res == null)
                return NotFound();
            return Ok(_productAppServices.GetAllProduct());
        }
        
        
        public IHttpActionResult GetProductById(int id)
        {
            var res = _productAppServices.GetPoduct(id);
            if (res==null)
            
                return NotFound();
            
            return Ok(res);
        }

    }
}
