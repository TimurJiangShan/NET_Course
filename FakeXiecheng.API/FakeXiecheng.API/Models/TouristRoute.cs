using System;
using System.Collections.Generic;

namespace FakeXiecheng.API.Models
{
    public class TouristRoute
    {
        // 基础属性
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPresent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Features { get; set; }
        public string Fees { get; set; }
        public string Notes { get; set; }
        // 外键联系
        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; }
    }
}
