using System.Runtime.CompilerServices;
using System;
using System.Linq;

[assembly: InternalsVisibleTo("TestApp.Tests")]

namespace TestApp
{
    class Program
    {
        private const string ERROR_MESSAGE = "<Ошибка>";
        private const string INVALID_INPUT_DATA = "Неправильные входные данные";

        static bool IsPowerOfTwo(int x)
        {
            return x > 0 && (x & (x - 1)) == 0;
        }

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

                    if (sizeArr.Length < 2)
                        continue;

                    if (!IsPowerOfTwo(sizeArr[1]))
                    {
                        Console.Write(INVALID_INPUT_DATA);
                        continue;
                    }

                    Console.Write("Введите ноты: ");
                    string notesStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(notesStr))
                        continue;

                    int[] noteArr = notesStr.Trim().Split(" ").Select(int.Parse).ToArray();

                    if (noteArr.Any(q => !IsPowerOfTwo(q)))
                    {
                        Console.Write(INVALID_INPUT_DATA);
                        continue;
                    }

                    foreach (ParseNoteResult result in parser.Parse(sizeArr[0], sizeArr[1], noteArr))
                    {
                        if (!isFirst)
                            Console.Write(" | ");

                        Console.Write(result.IsSuccess
                            ? string.Join(" ", result.Group.Notes.Select(q => q.BaseValue.ToString()))
                            : ERROR_MESSAGE);

                        isFirst = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }

            }
        }
    }
}