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
    [RoutePrefix("api/territory")]
    public class TerritoryController : ApiController
    {
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IMapper _mapper;
        public TerritoryController(ITerritoryRepository territoryRepository, IMapper mapper)
        {
            _territoryRepository = territoryRepository;
            _mapper = mapper;
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

            var results = _mapper.Map<IEnumerable<TerritoryDto>>(_territoryRepository.GetAll());
            return Ok(results);
        }
    }
}
