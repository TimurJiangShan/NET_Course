using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // 指明哪些数据模型需要映射到数据库中，使用DbSet进行模型的映射
        public DbSet<TouristRoute> touristRoutes { get; set; }
        public DbSet<TouristRoutePicture> touristRoutePictures { get; set; }

        // 将AppDbContext对象注入到IOC容器中，在startup里面

    }
}
