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
        private static string locationDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PROAvoorbeeld.db3");
        private static string locationDBBackup = "/sdcard/";

        private static SQLiteAsyncConnection _database;
        public SQLiteDataService()
        {
            _database = new SQLiteAsyncConnection(locationDB);
            _database.CreateTableAsync<VideoGame>().Wait();
        }

        private void CopyDatabase(string fromPath, string toPath)
        {
            var bytes = System.IO.File.ReadAllBytes(fromPath);
            var fileCopyName = toPath;
            System.IO.File.WriteAllBytes(fileCopyName, bytes);
        }

        public void SaveBackup(string nameFile)
        {
            // adb pull this one 
            // example: adb pull /sdcard/backup.db
            CopyDatabase(locationDB, locationDBBackup + nameFile);
        }

        public void LoadBackup(string nameFile)
        {
            // adb push this one 
            // example: adb push newdb.db /sdcard/newdb.db
            CopyDatabase(locationDBBackup + nameFile, locationDB);
            _database = new SQLiteAsyncConnection(locationDB);
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
