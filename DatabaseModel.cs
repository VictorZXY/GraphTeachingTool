using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    #region Accounts database model
    [Table(Name = "ACCOUNTS")]
    class DB_Account
    {
        [Key]
        [Column(Name = "AccountID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int AccountID { get; set; }

        [Required]
        [Column(Name = "Username", DbType = "TEXT")]
        public string Username { get; set; }

        [Required]
        [Column(Name = "Password", DbType = "TEXT")]
        public string Password { get; set; }

        [Required]
        [Column(Name = "AccountType", DbType = "TEXT")]
        public string AccountType { get; set; }
    }

    [Table(Name = "TEACHERS")]
    class DB_Teacher
    {
        [Key]
        [Column(Name = "TeacherID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int TeacherID { get; set; }

        [Required]
        [Column(Name = "Forename", DbType = "TEXT")]
        public string Forename { get; set; }

        [Required]
        [Column(Name = "Surname", DbType = "TEXT")]
        public string Surname { get; set; }

        [Column(Name = "DateOfBirth", DbType = "TEXT")]
        public DateTime DateOfBirth { get; set; }

        [Column(Name = "Email", DbType = "TEXT")]
        public string Email { get; set; }

        [Required]
        [Column(Name = "School", DbType = "TEXT")]
        public string School { get; set; }

        [Required]
        [Column(Name = "AccountID", DbType = "INTEGER")]
        public int AccountID { get; set; }
    }

    [Table(Name = "STUDENTS")]
    class DB_Student
    {
        [Key]
        [Column(Name = "StudentID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int StudentID { get; set; }

        [Required]
        [Column(Name = "Forename", DbType = "TEXT")]
        public string Forename { get; set; }

        [Required]
        [Column(Name = "Surname", DbType = "TEXT")]
        public string Surname { get; set; }

        [Column(Name = "DateOfBirth", DbType = "TEXT")]
        public DateTime DateOfBirth { get; set; }

        [Column(Name = "Email", DbType = "TEXT")]
        public string Email { get; set; }

        [Required]
        [Column(Name = "School", DbType = "TEXT")]
        public string School { get; set; }

        [Required]
        [Column(Name = "Year", DbType = "INTEGER")]
        public int Year { get; set; }

        [Required]
        [Column(Name = "AccountID", DbType = "INTEGER")]
        public int AccountID { get; set; }
    }
    #endregion

    #region Accounts database context
    class AccountContext : DataContext
    {
        public Table<DB_Account> ACCOUNTS;
        public Table<DB_Teacher> TEACHERS;
        public Table<DB_Student> STUDENTS;

        public AccountContext(string connection) : base(connection) { }
    }
    #endregion

    #region Questions database model
    [Table(Name = "GRAPHS")]
    class DB_Graph
    {
        [Key]
        [Column(Name = "GraphID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int GraphID { get; set; }
    }

    [Table(Name = "QUESTIONBANK")]
    class DB_QuestionBank
    {
        [Key]
        [Column(Name = "QuestionID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int QuestionID { get; set; }

        [Required]
        [Column(Name = "ProblemDescription", DbType = "TEXT")]
        public string ProblemDescription { get; set; }

        [Column(Name = "GraphID", DbType = "INTEGER")]
        public int GraphID { get; set; }
    }

    [Table(Name = "TASKS")]
    class DB_Task
    {
        [Key]
        [Column(Name = "TaskID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int TaskID { get; set; }

        [Required]
        [Column(Name = "TaskDescription", DbType = "TEXT")]
        public string TaskDescription { get; set; }

        [Column(Name = "StartingVertex", DbType = "TEXT")]
        public char StartingVertex { get; set; }

        [Column(Name ="FinishingVertex", DbType = "TEXT")]
        public char FinishingVertex { get; set; }

        [Required]
        [Column(Name = "QuestionID", DbType = "INTEGER")]
        public int QuestionID { get; set; }

        [Column(Name = "AnswerValue", DbType = "TEXT")]
        public string AnswerValue { get; set; }

        [Column(Name = "GraphID", DbType = "INTEGER")]
        public int GraphID { get; set; }
    }

    [Table(Name = "ADJACENCYMATRICES")]
    class DB_AdjacencyMatrix
    {
        [Key]
        [Column(Name = "AdjacencyMatrixID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int AdjacencyMatrixID { get; set; }

        [Required]
        [Column(Name = "AdjacencyMatrixValue", DbType = "TEXT")]
        public string AdjacencyMatrixValue { get; set; }

        [Required]
        [Column(Name = "GraphID", DbType = "INTEGER")]
        public int GraphID { get; set; }
    }

    [Table(Name = "GRAPHIMAGES")]
    class DB_GraphImage
    {
        [Key]
        [Column(Name = "GraphImageID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        public int GraphImageID { get; set; }

        [Required]
        [Column(Name = "ImageFile", DbType = "TEXT")]
        public string ImageFile { get; set; }

        [Required]
        [Column(Name = "GraphID", DbType = "INTEGER")]
        public int GraphID { get; set; }
    }
    #endregion

    #region Questions database context
    class QuestionContext : DataContext
    {
        public Table<DB_Graph> GRAPHS;
        public Table<DB_QuestionBank> QUESTIONBANKS;
        public Table<DB_Task> TASKS;
        public Table<DB_AdjacencyMatrix> ADJACENCYMATRICES;
        public Table<DB_GraphImage> GRAPHIMAGES;

        public QuestionContext(string connection) : base(connection) { }
    }
    #endregion
}