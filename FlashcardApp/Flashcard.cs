using SQLite;

namespace FlashcardApp;

public class Flashcard
{
    [PrimaryKey, AutoIncrement]
    public int ID {get; set;}
    public string Front {get; set;}
    public string Back {get; set;}
}

