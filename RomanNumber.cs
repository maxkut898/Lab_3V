using System;
using System.Collections.Generic;
using System.Text;

public class RomanNumber : ICloneable, IComparable
{
    private string Roman_Number = "";
    private ushort Decimal_Number;
    //Конструктор получает число n, которое должен представлять объект класса
    public RomanNumber(ushort n)
    {
        Decimal_Number = n;

    }
    //Сложение римских чисел
    public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null)
        {
            throw new RomanNumberException("Некорректно введены входные данные!!");
        }
        return new RomanNumber((ushort)(n1.Decimal_Number + n2.Decimal_Number));
    }
    //Вычитание римских чисел
    public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.Decimal_Number - n2.Decimal_Number <= 0)
        {
            throw new RomanNumberException("Некорректно введены входные данные!!");
        }

        return new RomanNumber((ushort)(n1.Decimal_Number - n2.Decimal_Number));
    }
    //Умножение римских чисел
    public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null)
        {
            throw new RomanNumberException("Некорректно введены входные данные!!");
        }
        return new RomanNumber((ushort)(n1.Decimal_Number * n2.Decimal_Number));
    }
    //Целочисленное деление римских чисел
    public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.Decimal_Number / n2.Decimal_Number <= 0)
        {
            throw new RomanNumberException("Некорректно введены входные данные!!");
        }

        return new RomanNumber((ushort)(n1.Decimal_Number / n2.Decimal_Number));
    }
    //Возвращает строковое представление римского числа
    public override string ToString()
    {
        if (Roman_Number == "")
        {
            ushort n = Decimal_Number;
            if (n <= 0 || n >= 4000)
            {
                throw new RomanNumberException("Некорректно введено десятичное число!!");
            }

            string[] romanSymbols = new string[] { "M", "D", "C", "L", "X", "V", "I" };

            //численное текущего значение римского символа
            ushort romanSymbolValue = 1000;

            for (int i = 0; i < romanSymbols.Length; i += 2)
            {
                //берём старшую цифру числа
                int digit = n / romanSymbolValue;

                if (digit == 9)
                {
                    Roman_Number += romanSymbols[i] + romanSymbols[i - 2];
                    digit = 0;
                }
                if (digit >= 5)
                {
                    Roman_Number += romanSymbols[i - 1];
                    digit -= 5;
                }
                if (digit == 4)
                {
                    Roman_Number += romanSymbols[i] + romanSymbols[i - 1];
                    digit = 0;
                }
                for (int j = 0; j < digit; j++)
                {
                    Roman_Number += romanSymbols[i];
                }

                //обрубаем старшую цифру числа
                n %= romanSymbolValue;

                //уменьшаем численное значение символа в 10 раз
                romanSymbolValue /= 10;
            }
        }
        return Roman_Number;
    }

    public object Clone()
    {
        return new RomanNumber(Decimal_Number);
    }

    public int CompareTo(object? o)
    {
        if (o is RomanNumber number)
        {
            return number.Decimal_Number - Decimal_Number;
        }
        else throw new ArgumentException("Некорректное значение параметра!!");
    }
}