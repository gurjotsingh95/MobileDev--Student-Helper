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

            registerTeacherButton.Click += delegate {
                EditText prevExperience = FindViewById<EditText>(Resource.Id.ExperienceID);
            };


            registerStudentButton.Click += delegate { };



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