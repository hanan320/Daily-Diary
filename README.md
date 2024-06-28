## How the Code Works

### Main Entry Point (`Program.cs`)

The `Program.cs` file initializes the application by creating an instance of the `DailyDiary` class with a specified diary file path (`diary.txt` by default). It then starts the application by invoking the `Run()` method.

### DailyDiary Class (`DailyDiary.cs`)

- **Initialization**: Upon instantiation, this class loads existing diary entries from the specified text file (`diary.txt`).
  
- **Functionality**:
  - **Read Entries**: Displays all existing diary entries stored in memory.
  - **Add Entry**: Allows users to append new entries with a specified date and content.
  - **Delete Entry**: Supports removal of entries based on a specified date.
  - **Count Entries**: Shows the total number of entries currently stored.
  - **Search Entries**: Enables searching for entries based on specific dates or content keywords.
  
- **Persistence**: Uses file operations to save entries to and load entries from `diary.txt`.

### Entry Class (`Entry.cs`)

- Represents a single diary entry with properties for `Date` (type `DateTime`) and `Content` (type `string`).

### Unit Tests (`DiaryManagerTests` Directory)

- Contains Xunit tests to validate the functionality of `DailyDiary` class methods:
  - **ReadDiaryFile**: Ensures correct reading of entries from the diary text file.
  - **AddEntry**: Verifies that adding an entry increases the total count of entries.

### Error Handling

- Basic error handling is implemented to manage exceptions during file operations or user input validation.

### Usage

- Users interact with the application through a console menu:
  - **Read Diary**: Displays all existing diary entries.
  - **Add Entry**: Prompts for a date and content to add a new entry.
  - **Delete Entry**: Asks for a date to remove the corresponding entry.
  - **Count Entries**: Shows the total number of entries.
  - **Search Entries**: Allows searching by date or content keyword to find specific entries.
  - **Exit**: Terminates the application.
