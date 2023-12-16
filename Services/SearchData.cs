using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace Demo.Search
{
    class SearchData
    {
        private string indexFilename;
        private SQLiteConnection? db;
        private string localPath;


        public SearchData(string localPath, string filename)
        {
            this.localPath = localPath;
            this.indexFilename = filename;
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
            string queryStatement = "SELECT id, lang, title, published_date FROM search_index WHERE lang = ? AND search_index MATCH ?";
            List<ContentItem> results = db!.Query<ContentItem>(queryStatement, new string[] { lang, text });
            return results;
        }

        public void AddItems(List<ContentItem> items)
        {
            db!.BeginTransaction();
            string createStatement = "CREATE VIRTUAL TABLE IF NOT EXISTS search_index using FTS5(id, lang, title, published_date, content)";
            db.Execute(createStatement);
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                string countStatement = "SELECT COUNT(*) FROM search_index WHERE id = ?";
                var count = db.Query<int>(countStatement, new string[] { item.Id });
                if (count.Count > 0 && count[0] > 0)
                {
                    string updateStatement = "UPDATE search_index SET lang = ?, title = ?, published_date = ?, content = ? WHERE id = ?";
                    db.Execute(updateStatement, new string[] { item.Id, item.Lang, item.Title, "", "" });
                }
                else
                {
                    string insertStatement = "INSERT INTO search_index VALUES (?, ?, ?, ?, ?)";
                    db.Execute(insertStatement, new string[] { item.Id, item.Lang, item.Title, "", "" });
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
