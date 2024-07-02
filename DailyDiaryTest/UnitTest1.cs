using System;
using System.IO;
using System.Reflection.Metadata;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiaryManager.Tests
{
    public class DailyDiaryTests 
    {
        [Fact]
        public void Readcontent()
        {
            // Arrange
            string path = @"..\..\..\DiaryTest.txt";
          
            
            DailyDiary dailyDiary = new DailyDiary(path);
            
            string dateInput= "2024-06-28";
            string content= "Today I went to the beach. It was a sunny day, and the weather was perfect for a swim.I spent a few hours relaxing by the shore, reading a book, and enjoying the sound of the waves.In the afternoon, I had a delicious picnic lunch with my friends, followed by a game of beach volleyball.Later in the evening, we watched the sunset and had a bonfire. It was an amazing day!";
            

            dailyDiary.AddEntry(dateInput, content);


            //Act
            bool result = dailyDiary.isAdded;
            
           

            //assert

            Assert.Equal(true, result);
          

        }
        [Fact]
        public void testCount() {

            // Arrange
            string path = @"..\..\..\DiaryTest.txt";
            DailyDiary dailyDiary = new DailyDiary(path);
            int num = dailyDiary.entries.Count;

            //Act
            int result = dailyDiary.CountEntries();

            //Assert
            Assert.Equal(num, result);

        }
        [Fact]
        public void testReadFile()
        {

            // Arrange
            string path = @"..\..\..\DiaryTest.txt";
            DailyDiary dailyDiary = new DailyDiary(path);
            bool isread = true;


            //Act
            bool result = dailyDiary.ReadDiaryFile();
            

            //Assert
            Assert.Equal(isread, result);

        }



    }
}
