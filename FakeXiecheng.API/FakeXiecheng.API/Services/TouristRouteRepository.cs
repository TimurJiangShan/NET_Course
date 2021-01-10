using System;
using System.Collections.Generic;
using System.Linq;
using FakeXiecheng.API.Database;
using FakeXiecheng.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeXiecheng.API.Services
{
    public class TouristRouteRepository: ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault(n => n.Id == touristRouteId);
        }
        // C#中，Linq to SQL 的返回类型就是 IQueryable: 叠加处理Linq语句，最后返回数据库，这个处理过程叫延迟执行
        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
        {
            // include vs join
            // 把图片信息也加载进来

            // 1. 这句语句的作用： 使用IQueryable，产生了一个查询TouristRoute表，并连接TouristRoutePictures表的SQL语句。
            // 但是这一步只是生成了SQL语句，并没有执行数据库查询的操作
            IQueryable<TouristRoute> result = _context.TouristRoutes.Include(t => t.TouristRoutePictures);

            // 2. 判断Keyword的情况
            if (keyword != null && keyword != "") // if(!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim(); // 消除keyword中多余的空格。
                result = result.Where(t => t.Title.Contains(keyword));
            }

            // 通过调用 ToList 函数， IQueryable 就会马上去执行数据库的访问，紧接着数据库的数据就会被查询出来了。而数据的类型则不是IQuerytable，
            // 而是以列表形式、以旅游路线模型封装的、实实在在的数据。（FirstOrDefault也是这个功能）。
            // FirstOrDefault和 ToList的区别是： FirstOrDefault处理的是一条单独的数据，而ToList处理的是列表类型的数据。
            return result.ToList();
        }

        public bool TouristRouteExists(Guid touristRouteId)
        {
            return _context.TouristRoutes.Any(t => t.Id == touristRouteId);
        }

        public IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId)
        {
            return _context.TouristRoutePictures.Where(p => p.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoutePicture GetPicture(int pictureId)
        {
            return _context.TouristRoutePictures.Where(p => p.Id == pictureId).FirstOrDefault();
        }
    }
}
