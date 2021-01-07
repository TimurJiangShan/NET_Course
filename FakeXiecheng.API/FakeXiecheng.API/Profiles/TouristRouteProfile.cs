﻿using System;
using AutoMapper;
using FakeXiecheng.API.Dtos;
using FakeXiecheng.API.Models;

namespace FakeXiecheng.API.Profiles
{
    public class TouristRouteProfile: Profile
    {
        public TouristRouteProfile()
        {
            // 自动映射两个对象中名字相同的字段
            CreateMap<TouristRoute, TouristRouteDto>().ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPercent ?? 1))
                )
                .ForMember(
                    dest => dest.TravelDays,
                    opt => opt.MapFrom(src => src.TravelDays.ToString())
                )
                .ForMember(
                    dest => dest.TripType,
                    opt => opt.MapFrom(src => src.TripType.ToString())
                )
                .ForMember(
                    dest => dest.DepartureCity,
                    opt => opt.MapFrom(src => src.DepartureCity.ToString())
                );
            ;
        }
    }
}