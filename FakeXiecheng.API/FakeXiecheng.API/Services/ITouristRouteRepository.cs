using System;
using System.Collections.Generic;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        // 返回一组旅游路线
        IEnumerable<TouristRoute> GetTouristRoutes();
        // 返回一个旅游路线
        TouristRoute GetTouristRoute(Guid touristRouteId);
    }
}
