using System;
using System.Collections.Generic;
// 对数据库进行限定
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeXiecheng.API.Models
{
    public class TouristRoute
    {
        // 基础属性
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
        /*
            可空的，nullable，所以加个问号，问号在C#中表示可空变量，
            转换为数据库，则代表一个列可以没有初始数据。
         */
        [Range(0.0, 1.0)]
        public double? DiscountPercent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        [MaxLength]
        public string Features { get; set; }
        [MaxLength]
        public string Fees { get; set; }
        [MaxLength]
        public string Notes { get; set; }
        // 外键联系
        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; } = new List<TouristRoutePicture>();
        public double? Rating { get; set; }
        public TravelDays? TravelDays {get;set;}
        public TripType? TripType { get; set; }
        public DepartureCity? DepartureCity { get; set; }
    }
}
