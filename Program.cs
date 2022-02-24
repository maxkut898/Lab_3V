using System;

class Program
{
    static void Main()
    {
        RomanNumber a = new RomanNumber(1999);
        RomanNumber b = new RomanNumber(648);
        RomanNumber c = new RomanNumber(7);
        RomanNumber d = new RomanNumber(49);

        Console.WriteLine("A = 1999 = MCMXCIX: " + a.ToString());
        Console.WriteLine("B = 648 = DCXLVIII: " + b.ToString());
        Console.WriteLine("C = 7 = VII: " + c.ToString());
        Console.WriteLine("D = 49 = XLIX: " + d.ToString());
        Console.WriteLine("");

        Console.WriteLine("B + C = 2006 = MMVI: " + RomanNumber.Add(b, c).ToString());
        Console.WriteLine("B - C = 1992 = MCMXCII: " + RomanNumber.Sub(b, c).ToString());
        Console.WriteLine("D * C = 343 = CCCXLIII: " + RomanNumber.Mul(d, c).ToString());
        Console.WriteLine("D / C = 7 = VII: " + RomanNumber.Div(d, c).ToString());
        Console.WriteLine("");

        Console.WriteLine("Сортировка:");
        RomanNumber[] numbers = { a, b, c, d };
        Array.Sort(numbers);

        foreach (RomanNumber number in numbers)
        {
            Console.WriteLine(number.ToString());
        }
        Console.WriteLine("");

        Console.WriteLine("Копирование:");
        var f = (RomanNumber)c.Clone();
        Console.WriteLine(f.ToString());
    }
}