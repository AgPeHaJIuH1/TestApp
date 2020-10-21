using System;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NoteParser parser = new NoteParser();

            while (true)
            {
                bool isFirst = true;
                try
                {
                    Console.Write("Введите размер: ");
                    string sizeStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(sizeStr))
                        continue;

                    int[] sizeArr = sizeStr.Trim().Split('/').Select(int.Parse).ToArray();

                    if(sizeArr.Length < 2)
                        continue;
                    
                    
                    Console.Write("Введите ноты: ");
                    string notesStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(notesStr))
                        continue;

                    int[] noteArr = notesStr.Trim().Split(" ").Select(int.Parse).ToArray();

                    foreach (NoteGroup group in parser.Parse(sizeArr[0], sizeArr[1], noteArr))
                    {
                        if (!isFirst)
                            Console.Write(" | ");

                        string groupStr = string.Join(" ", group.Notes.Select(q => q.BaseValue.ToString()));
                        Console.Write(groupStr);

                        isFirst = false;
                    }

                }
                catch (Exception ex)
                {
                    if (!isFirst)
                        Console.Write(" | ");
                    Console.Write("<Ошибка>");
                    //Console.Write(ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
