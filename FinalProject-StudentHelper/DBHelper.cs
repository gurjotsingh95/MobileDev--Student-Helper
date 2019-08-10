using System;
using Android.Content;  // Step: 1 - 0
using Android.Database.Sqlite; // Step: 1 - 1
using Android.Database;
using System.Collections.Generic;

namespace FinalProject_StudentHelper

{
    public class DBHelper : SQLiteOpenHelper
    {
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
        public const string CreateStudentTableQuery = "CREATE TABLE " + StudentTable + " ("
            + ColumnName + " TEXT," + ColumnPwd + " Text," + ColumnEmail + " VARCHAR2(20)," 
            + ColumnAge + " Text," + ColumnGender + " Text," + ColumnContact + " Number(11),"
            + ColumnCollege + " Text," + ColumnYear + " Number(5)," + ColumnField + " Text)";

     //Teacher Query
        public const string CreateTeacherTableQuery = "CREATE TABLE " + TeacherTable + " ("
             + ColumnName + " TEXT," + ColumnPwd + " Text," + ColumnEmail + " VARCHAR2,"
             + ColumnAge + " Text," + ColumnGender + " Text," + ColumnContact + " Number,"
            + ColumnSubject1 + " Text," + ColumnSubject2 + " Text," + ColumnExperience + " int," 
            + ColumnBio + " Text," + ColumnIndividualSession+ " Boolean," + ColumnGroupSession + " Boolean,"
            + ColumnTutoring + " Boolean," + ColumnVerification + " Boolean)";
        //Admin Query
        public const string CreateAdminTableQuery = "CREATE TABLE " + VerificationTable + " ("
              + ColumnTeacherId + " TEXT )";

        SQLiteDatabase myDBObj;
        Context myContext;

        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase; // Step:3 create a DB objects
        }
        public override void OnCreate(SQLiteDatabase db)  // Step: 1 - 2:1
        {
            db.ExecSQL(CreateStudentTableQuery);
            db.ExecSQL(CreateTeacherTableQuery);
            db.ExecSQL(CreateAdminTableQuery);
            Console.WriteLine(CreateTeacherTableQuery);
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) // Step: 1 - 2:2
        {
            throw new NotImplementedException();
        }
        // Student Insert Function
        public void insertValueStudent(string userNameValue, string pwdValue, string emailValue, string ageValue, string genderValue, string contactValue, string collegeValue, int yearValue, string fieldValue  )
        {
            String insertSQL = "insert into " + StudentTable + " values ('" + userNameValue + "'" + "," + "'" + pwdValue + "'" + "," 
                + "'" + emailValue + "'" + "," + "'" + ageValue + "'" + "," + "'" + genderValue + "'" + "," 
                + "'" + contactValue + "'" + "," + "'" + collegeValue + "'" + "," + "'" + yearValue + "'" + "," 
                + "'" + fieldValue + "'" + ");";

            Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);
        }
        public void insertValueTeacher(string userNameValue, string pwdValue, string emailValue, string ageValue, string genderValue, string contactValue, string subject1Value, string subject2Value, int experienceValue, string bioValue, Boolean individualSession, Boolean groupSession, Boolean homeTutor, Boolean Verification)
        {
            String insertSQL = "insert into " + TeacherTable + " values ('" + userNameValue + "'" + "," + "'" + pwdValue + "'" + ","
                + "'" + emailValue + "'" + "," + "'" + ageValue + "'" + "," + "'" + genderValue + "'" + "," 
                + "'" + contactValue + "'" + "," + "'" + subject1Value + "'" + "," + "'" + subject2Value + "'" + "," 
                + "'" + experienceValue + "'" + "," + "'" + bioValue + "'" + "," + "'" + individualSession + "'" + "," 
                + "'" + groupSession + "'" + "," + "'" + homeTutor + "'" + "," + "'" + Verification + "'" + ");";

            Console.WriteLine("Insert SQL ===" + insertSQL);
            myDBObj.ExecSQL(insertSQL);

        }
        public void insertValueAdmin(string teacherEmailValue)
        {
            String insertSQL = "insert into " + VerificationTable + " values ('" + teacherEmailValue + "'" + ");";
            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);
        }

    }
}
