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
    [RoutePrefix("api/shipper")]
    public class ShipperController : ApiController
    {
        private IShipperRepository _shipperRepository;
        private readonly IMapper _mapper;
        public ShipperController(IShipperRepository shipperRepository, IMapper mapper)
        {
            _shipperRepository = shipperRepository;
            _mapper = mapper;
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

            var results = _mapper.Map<IEnumerable<ShipperDto>>(_shipperRepository.GetAll());
            return Ok(results);
        }
    }
}
