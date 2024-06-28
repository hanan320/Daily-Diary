using System;
using System.IO;

namespace DiaryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "diary.txt");
            DailyDiary diary = new DailyDiary(filePath);
            diary.Run();
        }
    }
}
