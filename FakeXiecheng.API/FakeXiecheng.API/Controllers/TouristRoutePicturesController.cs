using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FakeXiecheng.API.Dtos;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController: ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        private IMapper _mapper;

        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository ?? throw new ArgumentNullException(nameof(touristRouteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if(!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictruesFromRepo = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);
            if (pictruesFromRepo == null || pictruesFromRepo.Count() <= 0)
            {
                return NotFound("照片不存在");
            }

            // 使用IEnumerable进行列表的映射
            var touristRoutePicturesDto = _mapper.Map<IEnumerable<TouristRoutePictureDto>>(pictruesFromRepo);
            return Ok(touristRoutePicturesDto);
        }

        [HttpGet("{pictureId}")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            // 处理有父子关系或者嵌套关系的时候，首先要取得父资源，然后在父资源的基础上再获得子资源，如果父资源不存在，那么最好也不要暴露子资源
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游路线不存在");
            }

            var pictureFromRepo = _touristRouteRepository.GetPicture(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("相片不存在");
            }

            var touristRoutePictureDto = _mapper.Map<TouristRoutePictureDto>(pictureFromRepo);
            return Ok(touristRoutePictureDto);
        }
    }
}
