using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



class Program {
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть що ви хочите зробити");
        string action = Console.ReadLine();

        if (action == "Edit")
        {
            RW("INFO.txt");
        }
        else if (action == "Show")
        {
            RD("INFO.txt");
        }
    }

    static void RW(string filename)
    {
        using (StreamWriter sw = File.AppendText(filename))
        {

                string name = Console.ReadLine();
                string surname = Console.ReadLine();
                int chemistry = int.Parse(Console.ReadLine());
                int math = int.Parse(Console.ReadLine());
                int english = int.Parse(Console.ReadLine());
                int oop = int.Parse(Console.ReadLine());

                sw.WriteLine($"{name} {surname} {chemistry} {math} {english} {oop}");
            
        }
    }

    static void RD(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        
            int i = 0;
            string[] names = new string[100];
            string[] surnames = new string[100];
            double[] chemistry = new double[100];
            double[] math = new double[100];
            double[] english = new double[100];
            double[] oop = new double[100];

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                names[i] = parts[0];
                surnames[i] = parts[1];
                chemistry[i] = double.Parse(parts[2]);
                math[i] = double.Parse(parts[3]);
                english[i] = double.Parse(parts[4]);
                oop[i] = double.Parse(parts[5]);
                i++;
            }

            Array.Sort(chemistry, names, 0, i, Comparer<double>.Create((x, y) => y.CompareTo(x)));
            Array.Sort(math, names, 0, i, Comparer<double>.Create((x, y) => y.CompareTo(x)));
            Array.Sort(english, names, 0, i, Comparer<double>.Create((x, y) => y.CompareTo(x)));
            Array.Sort(oop, names, 0, i, Comparer<double>.Create((x, y) => y.CompareTo(x)));

            Console.WriteLine("Хімія: " + string.Join(" ", chemistry.Take(i)));
            Console.WriteLine("Математика: " + string.Join(" ", math.Take(i)));
            Console.WriteLine("Англійська: " + string.Join(" ", english.Take(i)));
            Console.WriteLine("ООП: " + string.Join(" ", oop.Take(i)));
        
    }
}
