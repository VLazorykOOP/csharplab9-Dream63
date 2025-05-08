using System.Collections;

namespace  Lab9CSharp.Lab9CSharpTask3 {
    public class Task3 {

        string inputFile = "text.txt";
        string inputFile1 = "text1.txt";
        string outputFile = "output.txt";
        string path = "D:\\GitStudy\\cross-platform\\lab9csharp25-Dream63\\Lab9CSharp\\Lab9SCharpTask3\\";
       
        public void Task() {
            Task1();
            Task2();
        }

        private void Task1() 
        {
            Console.WriteLine("\n >>> Task 3.1");

            ArrayList numbers = new ArrayList();

            foreach (var line in File.ReadLines(path + inputFile))
                if (int.TryParse(line, out int num))
                    numbers.Add(num);

            using (StreamWriter writer = new StreamWriter(path + outputFile))
            {
                for (int i = 1; i <= numbers.Count; i++)
                    writer.WriteLine(numbers[^i]);
            }

            Console.WriteLine($"Числа записані у зворотному порядку у файл '{outputFile}'.");
        }
        private void Task2() {
            Console.WriteLine("\n >>> Task 3.2");
            ArrayList nonDigits = new ArrayList();
            ArrayList digits = new ArrayList();

            foreach (var line in File.ReadLines(path + inputFile1))
            {
                foreach (char ch in line)
                {
                    if (char.IsDigit(ch))
                        digits.Add(ch);
                    else
                        nonDigits.Add(ch);
                }
                nonDigits.Add('\n');
            }

            Console.WriteLine("Символи (не цифри):");
            PrintList(nonDigits);

            Console.WriteLine("\nЦифри:");
            PrintList(digits);
        }

        static void PrintList(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.Write(item);
            }
        }
    }
}