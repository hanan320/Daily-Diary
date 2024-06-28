using System;
using System.IO;
using Xunit;

namespace DiaryManager.Tests
{
    public class DailyDiaryTests : IDisposable
    {
        private readonly string testFilePath = Path.Combine(Environment.CurrentDirectory, "test_diary.txt");

        public DailyDiaryTests()
        {
            // Set up a test diary file with sample entries
            File.WriteAllText(testFilePath, "2024-06-01\nFirst entry\n2024-06-05\nSecond entry\n");
        }

        public void Dispose()
        {
            // Clean up the test diary file after tests
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Fact]
        public void AddEntry_ShouldIncreaseEntryCount()
        {
            // Arrange
            var diary = new DailyDiary(testFilePath);
            var initialCount = diary.entries.Count; // Capture initial count of entries

            // Act
            diary.AddEntry(); // Add a new entry

            // Assert
            var updatedCount = diary.entries.Count; // Capture updated count of entries
            Assert.Equal(initialCount + 1, updatedCount); // Check that count increased by 1
        }
    }
}
