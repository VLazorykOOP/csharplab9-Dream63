namespace  Lab9CSharp.Lab9CSharpTask1 {
    public class Task1 {
        string inputFile = "text.txt";
        string outputFile = "output.txt";
        string path = "D:\\GitStudy\\cross-platform\\lab9csharp25-Dream63\\Lab9CSharp\\Lab9SCharpTask1\\";
        public void Task() {
            Console.WriteLine("\n >>> Task 1");

            Stack<int> numbers = new();

            foreach (var line in File.ReadLines(path + inputFile))
                if (int.TryParse(line, out int num))
                    numbers.Push(num);

            using (StreamWriter writer = new StreamWriter(path + outputFile))
            {
                while (numbers.Count > 0)
                {
                    int num = numbers.Pop();
                    writer.WriteLine(num);
                }
            }
            Console.WriteLine($"Числа записано у файл '{outputFile}' у зворотному порядку.");
        }
    }
}