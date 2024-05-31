using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

class HelloWorld
{


    public static void Main(string[] args)
    {
        Console.WriteLine("Введите имя:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Введите фамилию:");
        string lastName = Console.ReadLine();

        int age = GetValidNumber("Введите возраст:");

        Console.WriteLine("Есть ли у вас питомец? (да/нет):");
        bool hasPet = Console.ReadLine() == "да";

        string[] petNames = null;
        if (hasPet)
        {
            int pet = GetValidNumber("Введите количество питомцев:");
            petNames = GetPetNames(pet);
        }

        int favColor = GetValidNumber("Введите количество любимых цветов:");
        string[] favoriteColors = GetFavoriteColors(favColor);

       
    }

    static int GetValidNumber(string message)
    {
        int number;
        bool isValidInput;
        do
        {
            Console.WriteLine(message);
            isValidInput = int.TryParse(Console.ReadLine(), out number) && number > 0;
            if (!isValidInput)
            {
                Console.WriteLine("Пожалуйста, введите корректное число (целое число больше 0).");
            }
        } while (!isValidInput);
        return number;
    }

    static string[] GetPetNames(int count)
    {
        string[] petNames = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите кличку питомца {i + 1}:");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    static string[] GetFavoriteColors(int count)
    {
        string[] favoriteColors = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите любимый цвет {i + 1}:");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }

   

}


        
    




























