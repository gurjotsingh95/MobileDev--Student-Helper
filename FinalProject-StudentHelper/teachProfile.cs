using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FinalProject_StudentHelper
{
    [Activity(Label = "teachProfile")]
    public class teachProfile : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.profile);
            var email = Intent.GetStringExtra("userEmail");
            var pass = Intent.GetStringExtra("password");
            var profileType = Intent.GetStringExtra("loginAs");

            Button edit = FindViewById<Button>(Resource.Id.Edit);
            Button save = FindViewById<Button>(Resource.Id.Save);
            save.Enabled = false;

            EditText nameET = FindViewById<EditText>(Resource.Id.name);
            EditText bioET = FindViewById<EditText>(Resource.Id.bio);
            EditText emailET = FindViewById<EditText>(Resource.Id.EmailID);
            EditText passET = FindViewById<EditText>(Resource.Id.PasswordID);
            EditText  ageET = FindViewById<EditText>(Resource.Id.AgeID);
            EditText  contactET = FindViewById<EditText>(Resource.Id.ContactID);
            EditText  genderET = FindViewById<EditText>(Resource.Id.GenderID);
            EditText  subject1ET = FindViewById<EditText>(Resource.Id.subject1ID);
            EditText  subject2ET = FindViewById<EditText>(Resource.Id.subject2ID);

            DBHelper sqlFunctions = new DBHelper(this);
            ICursor details = sqlFunctions.getUserDetails(email, pass, profileType);
            while (details.MoveToNext())
            {
                Console.WriteLine(" Value  Of Name  FROM DB  --> " + details.GetString(details.GetColumnIndexOrThrow("Name")));

                nameET.Text = details.GetString(details.GetColumnIndexOrThrow("Name"));
                bioET.Text = details.GetString(details.GetColumnIndexOrThrow("Bio"));
                emailET.Text = email;
                passET.Text = pass;
                ageET.Text = details.GetString(details.GetColumnIndexOrThrow("Age"));
                contactET.Text = details.GetString(details.GetColumnIndexOrThrow("Contact"));
                genderET.Text = details.GetString(details.GetColumnIndexOrThrow("gender"));
                subject1ET.Text = details.GetString(details.GetColumnIndexOrThrow("Subject1"));
                subject2ET.Text = details.GetString(details.GetColumnIndexOrThrow("Subject2"));
            }
            edit.Click += delegate
            {
                nameET.Enabled = true;
                bioET.Enabled = true;
                emailET.Enabled = true;
                passET.Enabled = true;
                ageET.Enabled = true;
                contactET.Enabled = true;
                genderET.Enabled = true;
                subject1ET.Enabled = true;
                subject2ET.Enabled = true;
                edit.Enabled = false;
                edit.Visibility = ViewStates.Invisible;
                save.Enabled = true;
                save.Visibility = ViewStates.Visible;
            };
            save.Click += delegate
            {
                nameET.Enabled = false;
                bioET.Enabled = false;
                emailET.Enabled = false;
                passET.Enabled = false;
                ageET.Enabled = false;
                contactET.Enabled = false;
                genderET.Enabled = false;
                subject1ET.Enabled = false;
                subject2ET.Enabled = false;
                edit.Enabled = true;
                edit.Visibility = ViewStates.Visible;
                save.Enabled = false;
                save.Visibility = ViewStates.Invisible;
            };
        }
    }
}