using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Get请求没有body。可以使用请求头部的header,添加媒体类型, 设置 accept application/json

namespace FakeXiecheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _touristRouteRepository = touristRouteRepository;
        }

        // action函数会自动匹配控制器的路由

        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var routes = _touristRouteRepository.GetTouristRoutes();
            return Ok(routes);
        }

        // 花括号填动态变量
        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            return Ok(_touristRouteRepository.GetTouristRoute(touristRouteId));
        }
    }
}
