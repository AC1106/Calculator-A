using System;
using System.Collections.Generic;

class Calculator
{
    static double memory = 0;
    static List<string> history = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("選擇操作：");
            Console.WriteLine("1. 加法");
            Console.WriteLine("2. 減法");
            Console.WriteLine("3. 乘法");
            Console.WriteLine("4. 除法");
            Console.WriteLine("5. 平方根");
            Console.WriteLine("6. 指數運算");
            Console.WriteLine("7. 儲存到記憶");
            Console.WriteLine("8. 從記憶讀取");
            Console.WriteLine("9. 清除記憶");
            Console.WriteLine("10. 複數加法");
            Console.WriteLine("11. 複數減法");
            Console.WriteLine("12. 查看歷史記錄");
            Console.WriteLine("0. 退出");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0) break;

            double num1, num2;

            switch (choice)
            {
                case 1:
                    Console.Write("輸入第一個數字：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("輸入第二個數字：");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    double resultAdd = Add(num1, num2);
                    Console.WriteLine($"結果：{resultAdd}");
                    SaveHistory($"{num1} + {num2} = {resultAdd}");
                    break;

                case 2:
                    Console.Write("輸入第一個數字：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("輸入第二個數字：");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    double resultSubtract = Subtract(num1, num2);
                    Console.WriteLine($"結果：{resultSubtract}");
                    SaveHistory($"{num1} - {num2} = {resultSubtract}");
                    break;

                case 3:
                    Console.Write("輸入第一個數字：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("輸入第二個數字：");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    double resultMultiply = Multiply(num1, num2);
                    Console.WriteLine($"結果：{resultMultiply}");
                    SaveHistory($"{num1} * {num2} = {resultMultiply}");
                    break;

                case 4:
                    Console.Write("輸入第一個數字：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("輸入第二個數字：");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    double resultDivide = Divide(num1, num2);
                    Console.WriteLine($"結果：{resultDivide}");
                    SaveHistory($"{num1} / {num2} = {resultDivide}");
                    break;

                case 5:
                    Console.Write("輸入數字：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    double resultSqrt = SquareRoot(num1);
                    Console.WriteLine($"結果：{resultSqrt}");
                    SaveHistory($"√{num1} = {resultSqrt}");
                    break;

                case 6:
                    Console.Write("輸入基數：");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("輸入指數：");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    double resultPower = Power(num1, num2);
                    Console.WriteLine($"結果：{resultPower}");
                    SaveHistory($"{num1} ^ {num2} = {resultPower}");
                    break;

                case 7:
                    Console.Write("輸入要存儲的數字：");
                    memory = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("已存儲到記憶。");
                    break;

                case 8:
                    Console.WriteLine($"記憶中的數字：{memory}");
                    break;

                case 9:
                    memory = 0;
                    Console.WriteLine("記憶已清除。");
                    break;

                case 10:
                    ComplexOperation("加法");
                    break;

                case 11:
                    ComplexOperation("減法");
                    break;

                case 12:
                    DisplayHistory();
                    break;

                default:
                    Console.WriteLine("無效選擇，請重新輸入。");
                    break;
            }
        }
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("錯誤：除數不能為零");
            return 0;
        }
        return a / b;
    }

    static double SquareRoot(double a)
    {
        if (a < 0)
        {
            Console.WriteLine("錯誤：不能對負數取平方根");
            return 0;
        }
        return Math.Sqrt(a);
    }

    static double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }

    static void ComplexOperation(string operation)
    {
        Console.Write("輸入第一個複數（格式：a+bi）：");
        string input1 = Console.ReadLine();
        Console.Write("輸入第二個複數（格式：a+bi）：");
        string input2 = Console.ReadLine();

        ComplexNumber c1 = ParseComplex(input1);
        ComplexNumber c2 = ParseComplex(input2);
        ComplexNumber result;

        if (operation == "加法")
        {
            result = c1.Add(c2);
            Console.WriteLine($"結果：{result}");
            SaveHistory($"{c1} + {c2} = {result}");
        }
        else if (operation == "減法")
        {
            result = c1.Subtract(c2);
            Console.WriteLine($"結果：{result}");
            SaveHistory($"{c1} - {c2} = {result}");
        }
    }

    static ComplexNumber ParseComplex(string input)
    {
        string[] parts = input.Split(new char[] { '+', 'i' }, StringSplitOptions.RemoveEmptyEntries);
        double real = double.Parse(parts[0]);
        double imaginary = double.Parse(parts[1]);
        return new ComplexNumber(real, imaginary);
    }

    static void SaveHistory(string entry)
    {
        history.Add(entry);
    }

    static void DisplayHistory()
    {
        Console.WriteLine("計算歷史：");
        foreach (var entry in history)
        {
            Console.WriteLine(entry);
        }
    }
}

class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }

    public ComplexNumber Subtract(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}