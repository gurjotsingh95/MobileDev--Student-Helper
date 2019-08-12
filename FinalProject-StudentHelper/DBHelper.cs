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

        private const string StudentTable = "Student";
        private const string TeacherTable = "Teacher";
        private const string VerificationTable = "Admin";
        private const string FavouriteTable = "Favourite";

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
        private const string ColumnRating = "RatingValue";
        private const string ColumnRatingNumber = "NumberOfRatings";

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
            + ColumnTutoring + " Boolean," + ColumnVerification + " Boolean," +ColumnRating+ " int," +ColumnRatingNumber+ " int)";
        //Admin Query
        public const string CreateAdminTableQuery = "CREATE TABLE " + VerificationTable + " ("
              + ColumnTeacherId + " TEXT )";
        //Favourite
        public const string CreateFavTableQuery = "CREATE TABLE " + FavouriteTable + " ("
      + ColumnEmail + " TEXT )";

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
            db.ExecSQL(CreateFavTableQuery);
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
        public void insertValueTeacher(string userNameValue, string pwdValue, string emailValue, string ageValue, string genderValue, string contactValue, string subject1Value, string subject2Value, int experienceValue, string bioValue, Boolean individualSession, Boolean groupSession, Boolean homeTutor, Boolean Verification, int ratingValue, int ratingNumber)
        {
            String insertSQL = "insert into " + TeacherTable + " values ('" + userNameValue + "'" + "," + "'" + pwdValue + "'" + ","
                + "'" + emailValue + "'" + "," + "'" + ageValue + "'" + "," + "'" + genderValue + "'" + "," 
                + "'" + contactValue + "'" + "," + "'" + subject1Value + "'" + "," + "'" + subject2Value + "'" + "," 
                + "'" + experienceValue + "'" + "," + "'" + bioValue + "'" + "," + "'" + individualSession + "'" + "," 
                + "'" + groupSession + "'" + "," + "'" + homeTutor + "'" + "," + "'" + Verification + "'" + "," + "'" + ratingValue + "'" + "," + "'" + ratingNumber + "'" +");";
            Console.WriteLine("Insert SQL ===" + insertSQL);
            myDBObj.ExecSQL(insertSQL);

        }
        public void insertValueAdmin(string teacherEmailValue)
        {
            String insertSQL = "insert into " + VerificationTable + " values ('" + teacherEmailValue + "'" + ");";
            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);
        }
        public void insertValueFav(string teacherEmailValue)
        {
            String insertSQL = "insert into " + FavouriteTable + " values ('" + teacherEmailValue + "'" + ");";
            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);
        }
        public bool LoginValidation(string enteredEmail, string enteredPassword, string tableName)
        {
            string loginValidationQuery = "Select * from " + tableName + " where " + ColumnEmail + "=" + "'" + enteredEmail + "'"
                + " AND " + ColumnPwd + "=" + "'" + enteredPassword + "'";

            ICursor result = myDBObj.RawQuery(loginValidationQuery, null);
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICursor getUserDetails(string enteredEmail, string enteredPassword, string tableName)
        {
            string loginValidationQuery = "Select * from " + tableName + " where " + ColumnEmail + "=" + "'" + enteredEmail + "'"
                + " AND " + ColumnPwd + "=" + "'" + enteredPassword + "'";

            ICursor result = myDBObj.RawQuery(loginValidationQuery, null);
            return result;
        }
        public ICursor searchResult(string columnNameSelected, string searchTerm)
        {
            string searchQuery = "Select * from " + TeacherTable + " where " + columnNameSelected + " LIKE " + "'%" + searchTerm + "%'";

            ICursor result = myDBObj.RawQuery(searchQuery, null);
            return result;
        }
        public ICursor searchFavResult()
        {
            /*
SELECT a1, a2, b1, b2
FROM A
INNER JOIN B on B.f = A.f;*/
            string searchQuery = "Select * from " + FavouriteTable + " INNER JOIN " +TeacherTable+ " on " + FavouriteTable + ".Email = " + TeacherTable + ".Email" ;

            ICursor result = myDBObj.RawQuery(searchQuery, null);
            return result;
        }
        public int ratingCalc()
        {
            return 1;
        }
    }
}
