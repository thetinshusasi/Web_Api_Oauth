using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.DLL.DataModelsDTOs;
using WebAPI.DLL.IRepositories;


namespace WebAPITut.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

            var results = _mapper.Map<IEnumerable<CustomerDto>>(_customerRepository.GetAll());
            return Ok(results);
        }
    }
}
