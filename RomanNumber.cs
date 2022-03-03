using System;

public class RomanNumber : ICloneable, IComparable
{
	static char[] Roman_Value = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
	string Roman;

	static string Digit_10_to_Roman(int n, int pos)
	{
		string res = "";
		if (n >= 5 && n < 9) res += Roman_Value[pos + 1];
		if (n % 5 <= 3) res += new string(Roman_Value[pos], n % 5);
		else if (n % 5 == 4)
		{
			res += Roman_Value[pos];
			res += Roman_Value[pos + (n + 1) / 5];
		}
		return res;
	}

	static ushort Digit_Roman_to_10(char Z)
	{
		if (Z == Roman_Value[0]) return 1;
		if (Z == Roman_Value[1]) return 5;
		if (Z == Roman_Value[2]) return 10;
		if (Z == Roman_Value[3]) return 50;
		if (Z == Roman_Value[4]) return 100;
		if (Z == Roman_Value[5]) return 500;
		if (Z == Roman_Value[6]) return 1000;
		return 0;
	}

	static ushort Roman_to_10(RomanNumber? n1)
	{
		ushort res = 0;
		int i = 0;
		for (; i < n1.Roman.Length - 1; i++)
		{
			if (Digit_Roman_to_10(n1.Roman[i]) < Digit_Roman_to_10(n1.Roman[i + 1]))
			{
				res += (ushort)(Digit_Roman_to_10(n1.Roman[i + 1]) - Digit_Roman_to_10(n1.Roman[i]));
				i++;
			}
			else res += Digit_Roman_to_10(n1.Roman[i]);
		}
		if (i != n1.Roman.Length) res += Digit_Roman_to_10(n1.Roman[i]);
		return res;
	}

	public RomanNumber(ushort n)
	{
		if (n <= 0 || n >= 4000)
		{
			throw new RomanNumberException("На вход было подано некорректное число для перевода\n в римскую систему счисления (от 1 до 3999)");
		}
		Roman = "";
		int deg = 1000;
		for (int i = 0; i < 4; i++)
		{
			Roman += Digit_10_to_Roman((n % (deg * 10)) / deg, 6 - 2 * i);
			deg /= 10;
		}
	}

	public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
	{
		if (n1 == null || n2 == null)
		{
			throw new RomanNumberException("Одно из слагаемых суммы римских чисел неопределенно");
		}
		ushort d1 = Roman_to_10(n1);
		ushort d2 = Roman_to_10(n2);
		if (d1 + d2 >= 4000) throw new RomanNumberException("Полученная сумма превышает диапозон допустимых значений " + (d1 + d2));
		return new RomanNumber((ushort)(d1 + d2));
	}

	public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
	{
		if (n1 == null || n2 == null)
		{
			throw new RomanNumberException("Одно из чисел разности римских чисел неопределенно");
		}
		ushort d1 = Roman_to_10(n1);
		ushort d2 = Roman_to_10(n2);
		if (d1 - d2 <= 0) throw new RomanNumberException("Вычитаемое в разности целых чисел больше или равно уменьшаемого");
		return new RomanNumber((ushort)(d1 - d2));
	}

	public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
	{
		if (n1 == null || n2 == null)
		{
			throw new RomanNumberException("Один из множителей произведения римских чисел неопределенно");
		}
		ushort d1 = Roman_to_10(n1);
		ushort d2 = Roman_to_10(n2);
		if (d1 * d2 >= 4000) throw new RomanNumberException("Полученное произведение превышает диапозон допустимых значений " + (d1 * d2));
		return new RomanNumber((ushort)(d1 * d2));
	}

	public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
	{
		if (n1 == null || n2 == null)
		{
			throw new RomanNumberException("Одно из чисел частного римских чисел неопределенно");
		}
		ushort d1 = Roman_to_10(n1);
		ushort d2 = Roman_to_10(n2);
		if (d1 / d2 == 0) throw new RomanNumberException("Делитель частного римских чисел меньше делимого ");
		if (d1 % d2 > 0) throw new RomanNumberException("Делимое не кратно делимому, а дробных чисел в римской системе счисления нет");
		return new RomanNumber((ushort)(d1 / d2));
	}

	public object Clone()
	{
		return new RomanNumber(Roman_to_10(this));
	}

	public int CompareTo(object? obj)
	{
		if (obj is RomanNumber roman) return Roman_to_10(this).CompareTo(Roman_to_10(roman));
		else throw new ArgumentException("Некорректное значение параметра");
	}

	public override string ToString()
	{
		return Roman;
	}
}