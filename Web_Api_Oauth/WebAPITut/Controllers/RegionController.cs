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
    [RoutePrefix("api/region")]
    public class RegionController : ApiController
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {

            var results = _mapper.Map<IEnumerable<RegionDto>>(_regionRepository.GetAll());
            return Ok(results);
        }
    }
}
