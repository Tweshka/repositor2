using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class HelloWorld
{


    public static void Main(string[] args)
    {
        Console.Write("Введите имя: ");
        var name = Console.ReadLine();
        Console.Write("Ввведите возраст: ");
       


        var age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Тебя зовут {0} Твой возраст {1} ", name, age);
        Console.Write("Введите дату рождения: ");
        var birthdate = Console.ReadLine();
        Console.WriteLine("Твоя дата рождения{0}" ,birthdate);
        



    }
}



