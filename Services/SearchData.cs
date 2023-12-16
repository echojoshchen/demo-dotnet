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

        public List<SearchItem> searchMetadata(string statement, string text)
        {
            List<SearchItem> results = db!.Query<SearchItem>(statement, new string[] { text });
            return results;
        }

        public void insertItems(
            string countStatement,
            string insertStatement,
            string updateStatement,
            string finalizeStatement,
            List<string> ids,
            List<List<dynamic>> items
        )
        {
            db!.BeginTransaction();
            for (int i = 0; i < ids.Count && i < items.Count; i++)
            {
                var id = ids[i];
                var item = items[i];

                var count = db.Query<int>(countStatement, new string[] { id });
                if (count.Count > 0)
                {
                    item.Add(id);
                    db.Execute(updateStatement, item.ToArray());
                }
                else
                {
                    db.Execute(insertStatement, item.ToArray());
                }
            }
            db.Execute(finalizeStatement);
            db.Commit();
        }

        public void runStatement(string statement, List<string> args)
        {
            db!.Execute(statement, args.ToArray());
        }

        public void runStatementList(List<string> statementList)
        {
            db!.BeginTransaction();
            foreach (var statement in statementList)
            {
                db.Execute(statement);
            }
            db.Commit();
        }

        public List<SearchItem> getStatement(string statement, List<string> args)
        {
            List<SearchItem> results = db!.Query<SearchItem>(statement, args.ToArray());
            return results;
        }

        public string readFile(string filename)
        {
            return File.ReadAllText(localPath + Path.DirectorySeparatorChar + filename);
        }

        public void writeFile(string filename, string data)
        {
            File.WriteAllText(localPath + Path.DirectorySeparatorChar + filename, data);
        }

        public string getIndexDate(string statement)
        {
            try {
                var results = db!.QueryScalars<string>(statement);
                return results[0];
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void openDb() {
            try {
                db = new SQLiteConnection(getIndexPath());
            }
            catch (Exception e) {
                throw new SearchConfigError(SearchConfigErrorType.dbError, e.Message);
            }
        }

        private string getIndexPath() {
            return localPath + Path.DirectorySeparatorChar + indexFilename;
        }
    }
}
