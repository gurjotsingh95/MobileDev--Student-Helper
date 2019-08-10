using System;
using Android.Content;  // Step: 1 - 0
using Android.Database.Sqlite; // Step: 1 - 1
using Android.Database;
using System.Collections.Generic;

namespace FinalProject_StudentHelper

{
    public class DBHelper : SQLiteOpenHelper  // Step: 1 - 2 // Class that you need extend 
    {

        //Step: 1 - 3:
        private static string _DatabaseName = "mydatabase.db";

        private const string StudentTable = "student";
        private const string TeacherTable = "Teacher";
        private const string VerificationTable = "Admin";

        //Admin
        private const string ColumnTeacherId = "TeacherId";


        //general
        private const string ColumnName = "Name";
        private const string ColumnPwd = "Password";
        private const string ColumnEmail = "Email";
        private const string ColumnAge = "Age";
        private const string ColumnGender = "gender";
        private const string ColumnContact = "Contact";
       
        //Student
        private const string ColumnCollege = "College";
        private const string ColumnYear = "Year";
        private const string ColumnField = "Field";

        //Teacher
        private const string ColumnSubject1 = "Subject1";
        private const string ColumnSubject2 = "Subject2";
        private const string ColumnExperience = "Experience";
        private const string ColumnBio = "Bio";
        private const string ColumnIndividualSession = "IndividualSession";
        private const string ColumnGroupSession = "GroupSession";
        private const string ColumnTutoring = "HomeTutoring";
        private const string ColumnVerification = "PendingVerification";


        //GeneralQuery             
        public const string CreateUserTableQuery = "CREATE TABLE " + StudentTable + " ("
            + ColumnName + " TEXT," + ColumnPwd + " Text," + ColumnEmail + " TEXT," 
            + ColumnAge + " Text," + ColumnGender + " Text," + ColumnContact + " Text,"
            + ColumnCollege + " Text," + ColumnYear + " Text," + ColumnField + " Text,)";  //Step: 1 - 4

     //Teacher Query
        public const string CreateTeacherTableQuery = "CREATE TABLE " + TeacherTable + " ("
             + ColumnName + " TEXT," + ColumnPwd + " Text," + ColumnEmail + " TEXT,"
             + ColumnAge + " Text," + ColumnGender + " Text," + ColumnContact + " Text,"
            + ColumnSubject1 + " Text," + ColumnSubject2 + " Text," + ColumnExperience + " Text," 
            + ColumnBio + " Text," + ColumnIndividualSession+ " Text," + ColumnGroupSession + " Text,"
            + ColumnTutoring + " Text," + ColumnVerification + " Text,)";

        //Admin Query
        public const string CreateAdminTableQuery = "CREATE TABLE " + VerificationTable + " ("
              + ColumnTeacherId + " TEXT, )";

        SQLiteDatabase myDBObj; // Step: 1 - 5
        Context myContext; // Step: 1 - 6

        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase; // Step:3 create a DB objects
        }


        public override void OnCreate(SQLiteDatabase db)  // Step: 1 - 2:1
        {

            db.ExecSQL(CreateUserTableQuery);  // Step: 4

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) // Step: 1 - 2:2
        {
            throw new NotImplementedException();
        }
    }
}
