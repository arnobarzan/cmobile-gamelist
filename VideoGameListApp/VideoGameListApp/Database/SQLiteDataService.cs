using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VideoGameListApp.Models;

namespace VideoGameListApp.Database
{
    public class SQLiteDataService
    {
        readonly SQLiteAsyncConnection _database;
        public SQLiteDataService()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OurDB2.db3");
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<VideoGame>().Wait();
        }

        public Task<List<VideoGame>> GetGamesAsync()
        {
            return _database.Table<VideoGame>().ToListAsync();
        }
        public Task<int> SaveGameAsync(VideoGame game)
        {
            if (game.Id != 0)
            {
                return _database.UpdateAsync(game);
            }
            else
            {
                return _database.InsertAsync(game);
            }
        }
    }
}
