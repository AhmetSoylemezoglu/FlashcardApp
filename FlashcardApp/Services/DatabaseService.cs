using SQLite;
using FlashcardApp.CardDecks; 

namespace FlashcardApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        
        async Task Init()
        {
            if (_database is not null)
                return; 
            
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "flashcards.db");

            _database = new SQLiteAsyncConnection(dbPath);
            
            await _database.CreateTableAsync<decksData>();
        }

        public async Task AddCard(decksData yeniKart)
        {
            await Init(); 
            await _database.InsertAsync(yeniKart);
        }

        public async Task<List<decksData>> GetAllCards()
        {
            await Init();
            return await _database.Table<decksData>().ToListAsync();
        }
    }
}