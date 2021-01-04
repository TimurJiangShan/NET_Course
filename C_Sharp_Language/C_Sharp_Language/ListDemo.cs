using System;
using System.Collections.Generic;

// foreach循环在C＃中是只读的

namespace C_Sharp_Language
{
    public class ListDemo
    {
        public ListDemo()
        {
            // 创建List
            var numbers = new List<int>() { 2,3,4,6,12,};
            var num2 = new List<int>();

            // Add()
            numbers.Add(1);

            // AddRange()
            numbers.AddRange(new int[3] { 5, 6, 7 });
            Console.WriteLine("------------------------------");
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
            // Remove()

            // RemoveAt()

            // IndexOf()

            // LastIndexOf()

            // Contains()

            // Count
        }
    }
}
