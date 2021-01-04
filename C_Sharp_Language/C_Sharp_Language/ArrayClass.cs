using System;
namespace C_Sharp_Language
{
    public class ArrayClass
    {
        public ArrayClass()
        {
            // 定义 jagged array
            var array = new int[3][];

            array[0] = new int[4];
            array[1] = new int[5];
            array[2] = new int[3];

            // Jagged
            var Jarray = new int[3][];

            // Rectangular
            var Rarray = new int[3,5];

            // Array的常见属性以及方法, Array是一种Class
            /*
            Length;

            Clear()
            
            Copy()

            IndexOf()

            Reverse()

            Sort()

            Reverse()
             */

            var numbers = new int[] { 3, 4, 4, 5, 56, 44, 23, 10, 2, 6, -1 };
            Console.WriteLine(numbers.Length);
            Console.WriteLine("------------------------------");
            Console.WriteLine(Array.IndexOf(numbers, 56));
            Console.WriteLine("----------- Clear Method ------------");
            Array.Clear(numbers, 0, 3);
            foreach (var n in numbers) {
                Console.WriteLine(n);
            }
            Console.WriteLine("------------ Copy Method ----------");
            int[] anotherArray = new int[10];
            Array.Copy(numbers, anotherArray, 5);
            foreach (var n in anotherArray)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------- Sort() --------");
            Array.Sort(numbers);
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("--------------  Reverse() --------");
            Array.Reverse(numbers);
            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }

        }
    }


}
