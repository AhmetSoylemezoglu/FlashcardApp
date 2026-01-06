using SQLite;

namespace FlashcardApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        
        async Task Init()
        {
            if (_database is not null)
                return; 
            
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Flashcards.db3");
            
            _database = new SQLiteAsyncConnection(dbPath);
            
            await _database.CreateTableAsync<Flashcard>();
        }

        public async Task<List<Flashcard>> GetFlashcardsAsync()
        {
            await Init();
            return await _database.Table<Flashcard>().ToListAsync();
        }

        public async Task<int> SaveFlashcardAsync(Flashcard card)
        {
            await Init();
            if (card.ID != 0)
            {
                return await _database.UpdateAsync(card); // öncdeden ID varsa güncelle. 
            }
            else
            {
                return await _database.InsertAsync(card); 
            }
        }
        
        public async Task<int> DeleteFlashcardAsync(Flashcard card)
        {
            await Init();
            return await _database.DeleteAsync(card);
        }
    }
}