using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Complex data model in database (Group A) is implemented here.
            // User/CASE-generated DDL script (Group A) is implemented here.
            #region DDL for database
            // Files organised for direct access (Group A) is implemented here.
            if (!System.IO.File.Exists("Database.sqlite"))
                SQLiteConnection.CreateFile("Database.sqlite");
            using (SQLiteConnection database = new SQLiteConnection("Data Source = Database.sqlite; Version = 3;"))
            {
                database.Open();
                string sql;

                #region DDL for Accounts database
                sql = "CREATE TABLE IF NOT EXISTS ACCOUNTS "
                    + "("
                    + "    AccountID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    Username TEXT NOT NULL UNIQUE,"
                    + "    Password TEXT NOT NULL,"
                    + "    AccountType TEXT NOT NULL"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS TEACHERS "
                    + "("
                    + "    TeacherID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    Forename TEXT NOT NULL,"
                    + "    Surname TEXT NOT NULL,"
                    + "    DateOfBirth TEXT,"
                    + "    Email TEXT,"
                    + "    School TEXT NOT NULL,"
                    + "    AccountID INTEGER NOT NULL UNIQUE,"
                    + "    FOREIGN KEY(AccountID) REFERENCES ACCOUNTS(AccountID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS STUDENTS "
                    + "("
                    + "    StudentID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    Forename TEXT NOT NULL,"
                    + "    Surname TEXT NOT NULL,"
                    + "    DateOfBirth TEXT,"
                    + "    Email TEXT,"
                    + "    School TEXT NOT NULL,"
                    + "    AccountID INTEGER NOT NULL UNIQUE,"
                    + "    FOREIGN KEY(AccountID) REFERENCES ACCOUNTS(AccountID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }
                #endregion

                #region DDL for Questions database
                sql = "CREATE TABLE IF NOT EXISTS GRAPHS "
                    + "("
                    + "    GraphID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    GraphFormat TEXT NOT NULL"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS QUESTIONBANK "
                    + "("
                    + "    QuestionID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    QuestionName TEXT NOT NULL,"
                    + "    DateModified TEXT NOT NULL,"
                    + "    ProblemDescription TEXT,"
                    + "    GraphID INTEGER NOT NULL,"
                    + "    FOREIGN KEY(GraphID) REFERENCES GRAPHS(GraphID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS TASKS "
                    + "("
                    + "    TaskID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    TaskDescription TEXT NOT NULL,"
                    + "    StartingVertex TEXT,"
                    + "    FinishingVertex TEXT,"
                    + "    QuestionID INTEGER NOT NULL,"
                    + "    AnswerValue TEXT,"
                    + "    GraphID INTEGER,"
                    + "    FOREIGN KEY(QuestionID) REFERENCES QUESTIONBANK(QuestionID),"
                    + "    FOREIGN KEY(GraphID) REFERENCES GRAPHS(GraphID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS ADJACENCYMATRICES "
                    + "("
                    + "    AdjacencyMatrixID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,";
                for (int i = 0; i < 26; i++)
                    for (int j = 0; j < 26; j++)
                        sql += "Edge" + Convert.ToChar('A' + i).ToString() + Convert.ToChar('A' + j).ToString() + " REAL,";
                for (int i = 0; i < 26; i++)
                    sql += "Vertex" + Convert.ToChar('A' + i).ToString() + " INTEGER NOT NULL,";
                sql += "   GraphID INTEGER NOT NULL,"
                    + "    FOREIGN KEY(GraphID) REFERENCES GRAPHS(GraphID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }

                sql = "CREATE TABLE IF NOT EXISTS GRAPHIMAGES "
                    + "("
                    + "    GraphImageID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
                    + "    ImageFileName TEXT NOT NULL,"
                    + "    GraphID INTEGER NOT NULL,"
                    + "    FOREIGN KEY(GraphID) REFERENCES GRAPHS(GraphID)"
                    + ");";
                using (SQLiteCommand command = new SQLiteCommand(sql, database))
                {
                    command.ExecuteNonQuery();
                }
                #endregion

                // This is used for the potential administrator control functionalities in future updates.
                //sql = "INSERT INTO ACCOUNTS (Username, Password, AccountType) "
                //    + "SELECT 'admin', '" + new MD5Hashing().Encrypt("admin") + "', 'ADMINISTRATOR' "
                //    + "WHERE NOT EXISTS (SELECT * FROM ACCOUNTS WHERE Username = 'admin' AND AccountType = 'ADMINISTRATOR');";
                //using (SQLiteCommand command = new SQLiteCommand(sql, database))
                //{
                //    command.ExecuteNonQuery();
                //}
            }
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
