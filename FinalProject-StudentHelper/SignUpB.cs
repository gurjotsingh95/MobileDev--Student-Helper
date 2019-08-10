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
            SetContentView(Resource.Layout.SignUp);
            LinearLayout teacher = FindViewById<LinearLayout>(Resource.Id.teacherLayout);
            LinearLayout student = FindViewById<LinearLayout>(Resource.Id.studentLayout);
            teacher.Enabled = false;
            student.Enabled = false;
            teacher.Visibility = ViewStates.Invisible;
            student.Visibility = ViewStates.Invisible;

            Button addSubButton = FindViewById<Button>(Resource.Id.AddSubjectButton);
            Button registerTeacherButton = FindViewById<Button>(Resource.Id.registerTeacher);
            Button registerStudentButton = FindViewById<Button>(Resource.Id.registerStudent);
            Button subject1 = FindViewById<Button>(Resource.Id.subject1);
            Button subject2 = FindViewById<Button>(Resource.Id.subject2);
            subject1.Enabled = false;
            subject1.Visibility = ViewStates.Invisible;
            subject2.Enabled = false;
            subject2.Visibility = ViewStates.Invisible;
            var userName = Intent.GetStringExtra("userName");
            var passWord = Intent.GetStringExtra("passWord");
            var eMail = Intent.GetStringExtra("eMail");
            var age = Intent.GetStringExtra("age");
            var gender = Intent.GetStringExtra("gender");
            var contact = Intent.GetStringExtra("contact");
            var registerType = Intent.GetStringExtra("registerType");

            string subject1Value = null;
            string subject2Value = null;
            Boolean homeTutorValue = false;
            Boolean individualSess = false;
            Boolean groupSess = false;
            //yes= tcher
            if(registerType == "Yes")
            {
                teacher.Enabled = true;
                teacher.Visibility = ViewStates.Visible;
            }
            else
            {
                student.Enabled = true;
                student.Visibility = ViewStates.Visible;
            }
            DBHelper sqlFunctions = new DBHelper(this);
            addSubButton.Click += delegate {
                EditText subjectName = FindViewById<EditText>(Resource.Id.SubjectsText);
                var subjectValue = subjectName.Text;
                if(subject1.Enabled == false)
                {
                    subject1.Text = subjectValue;
                   // subject1Value = subjectValue;
                    subject1.Enabled = true;
                    subjectName.Text = "";
                    subject1.Visibility = ViewStates.Visible;
                }
                else if(subject1.Enabled == true && subject2.Enabled == false)
                {
                    subject2.Text = subjectValue;
                  //  subject2Value = subjectValue;
                    subject2.Enabled = true;
                    subjectName.Text = "";
                    subject2.Visibility = ViewStates.Visible;
                }
                else
                {
                    Toast.MakeText(this, "Cannot add more than 2 subjects!!!", ToastLength.Short).Show();
                }
            };
            subject1.Click += delegate
            {
                deleteSubject(subject1);
            };
            subject2.Click += delegate
            {
                deleteSubject(subject2);
            };

            registerTeacherButton.Click += delegate {

                EditText prevExperience = FindViewById<EditText>(Resource.Id.ExperienceID);
                EditText bio = FindViewById<EditText>(Resource.Id.BioID);
                int exp = Convert.ToInt32(prevExperience.Text);
                var biography = bio.Text;

                CheckBox individualSessionCheck = FindViewById<CheckBox>(Resource.Id.checkInvidualID);
                CheckBox groupSessionCheck = FindViewById<CheckBox>(Resource.Id.checkGroupId);
                if(individualSessionCheck.Checked)
                {
                    individualSess = true;
                }
                if(groupSessionCheck.Checked)
                {
                    groupSess = true;
                }
                RadioGroup homeTutor = FindViewById<RadioGroup>(Resource.Id.radioHomeTutorId);
                RadioButton homeTutorSelect = FindViewById<RadioButton>(homeTutor.CheckedRadioButtonId);
                if(homeTutorSelect.Text == "Yes")
                {
                    homeTutorValue = true;
                }
                CheckBox verificationCheck = FindViewById<CheckBox>(Resource.Id.verificationId);
                
                if(verificationCheck.Checked)
                {
                    Console.WriteLine("USERNAME FROM SIGN UP A PAGE ON SIGN UP B ---"+userName);
                    //call insert to teacher db and insert to admin db
                    sqlFunctions.insertValueTeacher(userName, passWord, eMail, age, gender, contact, subject1.Text, subject2.Text, exp, biography, individualSess, groupSess, homeTutorValue, true);
                    sqlFunctions.insertValueAdmin(eMail);
                }
                else
                {
                    //call insert to teach table
                    sqlFunctions.insertValueTeacher(userName, passWord, eMail, age, gender, contact, subject1Value, subject2Value, exp, biography, individualSess, groupSess, homeTutorValue, true);

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
        protected void deleteSubject(Button subjectClicked)
        {
            subjectClicked.Visibility = ViewStates.Invisible;
            subjectClicked.Text = "";
            subjectClicked.Enabled = false;
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

                        if(subject1.Enabled == false)
                {
                    subject1.Text = subjectValue;
                    subject1Value = subjectValue;
                    subject1.Enabled = true;
                    subjectName.Text = "";
                    subject1.Visibility = ViewStates.Visible;

                }
        
        } */
    }
}