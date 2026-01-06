using SQLite;

namespace FlashcardApp.CardDecks
{
    [Table("flashcards")]
    public class decksData
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("front_text")]
        public string Front { get; set; }

        [Column("back_text")]
        public string Back { get; set; }
    }
}