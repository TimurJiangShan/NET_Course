using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FakeXiecheng.API.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Get请求没有body。可以使用请求头部的header,添加媒体类型, 设置 accept application/json

namespace FakeXiecheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        private readonly IMapper _mapper;

        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        // api/touristRoutes?keyword=传入的参数      keyword这里匹配的是问号后面的部分
        // action函数会自动匹配控制器的路由
        [HttpHead]
        [HttpGet]
        public IActionResult GetTouristRoutes([FromQuery] string keyword) // FromQuery vs FromBody
        {
            /*
             * [ApiController] 里面有attribute， 所以上面函数参数里面的 [FromQuery]是可以省略的， ASP会自动帮我们绑定URL中的参数，
             * 但是为了让代码更有逻辑性，还是不要省略这个attribute。 而且FromQuery还有另一个用处，就是如果url的参数命名与action函数
             * 参数的名称不一致，一定要使用FromQuery的name属性匹配一下， [FromQuery(name="")]。
             * 在这个项目中，参数的名称是一致的，所以不需要做这一步。
             * **/
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes(keyword);
            if (touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }

            // 使用IEnumerable进行列表的映射
            var touristRouteDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRoutesFromRepo);
            return Ok(touristRouteDto);
        }

        // api/touristRoutes/{touristRouteId}       touristRouteId 这里匹配的是花括号的中的参数
        // 花括号填动态变量
        [HttpGet("{touristRouteId}")]
        [HttpHead("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }
            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }
    }
}
