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
        /*
            可空的，nullable，所以加个问号，问号在C#中表示可空变量，
            转换为数据库，则代表一个列可以没有初始数据。
         */
        public double? DiscountPercent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string Features { get; set; }
        public string Fees { get; set; }
        public string Notes { get; set; }
        // 外键联系
        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; }
    }
}
