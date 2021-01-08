using System;
using AutoMapper;
using FakeXiecheng.API.Dtos;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Profiles
{
    public class TouristRoutePictureProfile: Profile
    {
        public TouristRoutePictureProfile()
        {
            // 需要更改映射项的时候才需要 ForMember()
            CreateMap<TouristRoutePicture, TouristRoutePictureDto>();
        }
    }
}
