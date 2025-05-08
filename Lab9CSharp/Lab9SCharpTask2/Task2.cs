namespace  Lab9CSharp.Lab9CSharpTask2 {
    public class Task2 {
        string inputFile = "text.txt";
        string path = "D:\\GitStudy\\cross-platform\\lab9csharp25-Dream63\\Lab9CSharp\\Lab9SCharpTask2\\";
        public void Task() {
            Console.WriteLine("\n >>> Task 2");


            Queue<char> nonDigits = new Queue<char>();
            Queue<char> digits = new Queue<char>();

            foreach (var line in File.ReadLines(path + inputFile)) {
                foreach (char ch in line)
                {
                    if (char.IsDigit(ch))
                        digits.Enqueue(ch);
                    else
                        nonDigits.Enqueue(ch);
                }
                nonDigits.Enqueue('\n');
            }

            Console.WriteLine("Символи:");
            while (nonDigits.Count > 0)
                Console.Write(nonDigits.Dequeue());

            Console.WriteLine("\nЦифри:");
            while (digits.Count > 0)
                Console.Write(digits.Dequeue());
        }
    }
}