using System;

namespace repositor2

{
    internal class Program;
    class MainClass
    {
        public static void Main(string[] args)
        {
            DaysOfWeek MyFavoriteDay;

            MyFavoriteDay = DaysOfWeek.sunday;

            Console.WriteLine(MyFavoriteDay);
        }
    }

    enum DaysOfWeek : byte
    {
        Tuesday,
        Monday,
        Wednesday,
        Friday,
        sunday
    }
}



