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

            var userName = Intent.GetStringExtra("userNameText");
            var passWord = Intent.GetStringExtra("passWordText");
            var eMail = Intent.GetStringExtra("eMailText");
            var age = Intent.GetStringExtra("ageText");
            var gender = Intent.GetStringExtra("genderText");
            long contact = Intent.GetLongExtra("contactText", 9999999999);


            registerTeacherButton.Click += delegate {

                Button subject1 = FindViewById<Button>(Resource.Id.subject1);
                Button subject2 = FindViewById<Button>(Resource.Id.subject2);

                EditText prevExperience = FindViewById<EditText>(Resource.Id.ExperienceID);
                EditText bio = FindViewById<EditText>(Resource.Id.BioID);

                RadioGroup homeTutor = FindViewById<RadioGroup>(Resource.Id.radioHomeTutorId);
                RadioButton selectedSchoolOrCollege = FindViewById<RadioButton>(homeTutor.CheckedRadioButtonId);

                CheckBox individualSessionCheck = FindViewById<CheckBox>(Resource.Id.checkInvidualID);
                CheckBox groupSessionCheck = FindViewById<CheckBox>(Resource.Id.checkGroupId);
                CheckBox verificationCheck = FindViewById<CheckBox>(Resource.Id.verificationId);

                if(verificationCheck.Checked)
                {
                    //call insert to teacher db and insert to admin db
                }
                else
                {
                    //call insert to teach table
                }
            };


            registerStudentButton.Click += delegate {
                EditText schoolCollegeName = FindViewById<EditText>(Resource.Id.nameSchoolCollegeID);
                EditText classOrYear = FindViewById<EditText>(Resource.Id.ClassOrYearId);
                EditText studyField = FindViewById<EditText>(Resource.Id.FieldId);

                RadioGroup inSchoolOrCollege = FindViewById<RadioGroup>(Resource.Id.radioSchoolCollegeID);
                RadioButton selectedSchoolOrCollege = FindViewById<RadioButton>(inSchoolOrCollege.CheckedRadioButtonId);

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