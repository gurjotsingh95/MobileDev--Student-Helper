using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FinalProject_StudentHelper
{
    [Activity(Label = "studentProfile")]
    public class studentProfile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfileStudent);

            // Create your application here
            /*private const string ColumnName = "Name";
        private const string ColumnPwd = "Password";
        private const string ColumnEmail = "Email";
        private const string ColumnAge = "Age";
        private const string ColumnGender = "gender";
        private const string ColumnContact = "Contact";
        //Student
        private const string ColumnCollege = "College";
        private const string ColumnYear = "Year";
        private const string ColumnField = "Field";*/
        }
    }
}