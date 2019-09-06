using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.DLL.IRepositories;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.DLL;
using WebAPI.DLL.DataModelsDTOs;

namespace WebAPITut.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct()
        {
           
            var products = _mapper.Map<IEnumerable<ProductDto>>(_productRepository.GetAll());
            return Ok(products);
        }

        //[Route("AddProduct")]
        //[HttpPost]
        //public async Task<IHttpActionResult> AddProduct(string name, decimal cost)
        //{
        //    _productRepository.Save(new Product()
        //    {
        //        Name = name,
        //        Cost = cost
        //    });
        //    return Ok();
        //}
    }
}
