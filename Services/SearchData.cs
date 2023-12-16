using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace Demo.Search
{
    class SearchData
    {
        private string indexFilename = "search.db";
        private SQLiteConnection? db;
        private string localPath;


        public SearchData(string localPath)
        {
            this.localPath = localPath;
            openDb();
        }

        ~SearchData()
        {
            closeDb();
        }

        public void reset()
        {
            closeDb();
            var indexPath = getIndexPath();
            if (File.Exists(indexPath))
            {
                File.Delete(indexPath);
            }
            openDb();
        }

        public void closeDb()
        {
            db!.Close();
            db.Dispose();
        }

        public List<ContentItem> GetResults(string lang, string text)
        {
            string queryStatement = "SELECT id, lang, title, published_date FROM search_index WHERE lang = ? AND content MATCH ?";
            List<ContentItem> results = db!.Query<ContentItem>(queryStatement, new string[] { lang, text });
            return results;
        }

        public void AddItems(List<ContentItem> items)
        {
            db!.BeginTransaction();
            string createStatement = "CREATE VIRTUAL TABLE IF NOT EXISTS search_index FTS5(id TEXT, lang TEXT, title TEXT, published_date TEXT, content TEXT)";
            db.Execute(createStatement);
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                string countStatement = "SELECT COUNT(*) FROM search_index WHERE id = ?";
                var count = db.Query<int>(countStatement, new string[] { item.Id });
                if (count.Count > 0)
                {
                    string updateStatement = "UPDATE search_index SET lang = ?, title = ?, published_date = ?, content = ? WHERE id = ?";
                    db.Execute(updateStatement, item.Id, item.Lang, item.Title, item.PublishedDate, item.Content);
                }
                else
                {
                    string insertStatement = "INSERT INTO search_index (id, lang, title, published_date, content) VALUES (?, ?, ?, ?, ?)";
                    db.Execute(insertStatement, item.Id, item.Lang, item.Title, item.PublishedDate, item.Content);
                }
            }
            db.Commit();
        }

        public void DeleteItems(List<string> ids)
        {
            db!.BeginTransaction();
            for (int i = 0; i < ids.Count; i++)
            {
                var id = ids[i];
                string deleteStatement = "DELETE FROM search_index WHERE id = ?";
                db.Execute(deleteStatement, id);
            }
            db.Commit();
        }

        private void openDb() {
            db = new SQLiteConnection(getIndexPath());
        }

        private string getIndexPath() {
            return localPath + Path.DirectorySeparatorChar + indexFilename;
        }
    }
}
