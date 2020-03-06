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
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;

        }
        [Route("getAll")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var temp = _employeeRepository.GetAll();
            var results = _mapper.Map<IEnumerable<EmployeeDto>>(temp);
            return Ok(results);
        }

    }
}
