using System;
using System.Text.RegularExpressions;

namespace FakeXiecheng.API.ResourceParameters
{
    public class TouristRouteResourceParameters
    {
        public string Keyword { get; set; }
        public string RatingOperator { get; set; }
        public int? RatingValue { get; set; }
        private string _rating;
        public string Rating {
            get
            { return _rating; }
            set
            {
                // value就是接收到的值, 对rating进行 null和空字符串的判断
                // 正则匹配两个部分
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Regex regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
                    Match match = regex.Match(value);
                    if (match.Success)
                    {
                        RatingOperator = match.Groups[1].Value;
                        RatingValue = Int32.Parse(match.Groups[2].Value);
                    }
                }
                _rating = value;
            }
        }
        public TouristRouteResourceParameters()
        {
        }
    }
}
