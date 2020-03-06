using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebAPI.DLL.DataModelsDTOs;
using WebAPI.DLL.IRepositories;
using System.Threading.Tasks;

namespace WebAPITut.Controllers
{
    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController
    {
        private readonly ISuppilerRepository _suppilerRepository;
        private readonly IMapper _mapper;
        public SupplierController(ISuppilerRepository suppilerRepository, IMapper mapper)
        {
            _suppilerRepository = suppilerRepository;
            _mapper = mapper;
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

            var results = _mapper.Map<IEnumerable<SupplierDto>>(_suppilerRepository.GetAll());
            return Ok(results);
        }
    }
}
