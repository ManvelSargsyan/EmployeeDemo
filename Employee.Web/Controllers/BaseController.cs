using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper mapper;
        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        protected async Task<IActionResult> ResponceAsync<TResponce>(Func<Task<TResponce>> action)
        {
            try
            {
                var responce = await action();

                return Ok(mapper.Map<TResponce>(responce));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
