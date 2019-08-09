using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FinalProject_StudentHelper
{
    [Activity(Label = "SignUpB")]
    public class SignUpB : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpTabB);
            Button registerTeacherButton = FindViewById<Button>(Resource.Id.registerTeacher);
            Button registerStudentButton = FindViewById<Button>(Resource.Id.registerStudent);

            long contact = Intent.GetLongExtra("contactText" , 9999999999);
            var userName = Intent.GetStringExtra("userNameText");
            var passWord = Intent.GetStringExtra("passWordText");
            var eMail = Intent.GetStringExtra("eMailText");
            var age = Intent.GetStringExtra("ageText");
            var gender = Intent.GetStringExtra("genderText");

            registerTeacherButton.Click += delegate {
                Button subject1 = FindViewById<Button>(Resource.Id.subject1);
                Button subject2 = FindViewById<Button>(Resource.Id.subject2);
                EditText prevExperience = FindViewById<EditText>(Resource.Id.ExperienceID);
                EditText bio = FindViewById<EditText>(Resource.Id.BioID);
            };


            registerStudentButton.Click += delegate {
                EditText schoolCollegeName = FindViewById<EditText>(Resource.Id.nameSchoolCollegeId);
                EditText classOrYear = FindViewById<EditText>(Resource.Id.classOrYearId);
                EditText studyField = FindViewById<EditText>(Resource.Id.FieldID);
            };



        }
        /*      protected void addSubjectToView()
              {
                  LinearLayout buttonLayout = FindViewById<LinearLayout>(Resource.Id.buttonLayout);

                  //     LinearLayout l1 = new LinearLayout(this);
                  Button addButton = new Button(this);
                  Button addButton2 = new Button(this);

                  addButton.Text = "subject1";
                  addButton2.Text = "subject2";

                  //    l1.AddView(addButton);
                  buttonLayout.AddView(addButton);
                  buttonLayout.AddView(addButton2);

              } */
    }
}